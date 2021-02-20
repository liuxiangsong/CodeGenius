using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using Microsoft.Office.Interop.Word;

using LibraryGenius;

namespace SqlCodeGenerator
{
    public class DBDataDocWord
    {
        #region 变量及属性
        public delegate void SetProcessBarHandler(int value);
        public static event SetProcessBarHandler SetProcessBarEvent;

        private Application WordApp = new Application();
        object template = Missing.Value;
        object missing = Type.Missing;
        object type = 11;
        object length = 0; 
        #endregion

        #region 生成Word文档
        /// <summary>
        /// 生成Word文档
        /// </summary>
        /// <param name="dbName">database name</param>
        /// <param name="ds">dataset(notice:every table must have a real table Name)</param>
        public void GenerateDocDBDocument(string dbName, DataSet ds)
        {
            Document document = this.CreateWordDocument(dbName);

            for (int item = 0; item < ds.Tables.Count; item++)
            {
                Table table = this.CreateWordTable(document, ds.Tables[item].TableName);
                this.AddTitleRowToWordTable(table);
                this.FillWordTable(table, ds.Tables[item]);
                table.Rows.First.Shading.Texture = WdTextureIndex.wdTexture25Percent;

                SetProcessBarEvent(item + 1);  //Set Processbar's current value
            }
            this.WordApp.Visible = true;
            document.Activate();
        } 
        #endregion

        #region 私有方法
        #region 创建WordDocument
        /// <summary>
        /// 创建WordDocument
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        private Document CreateWordDocument(string dbName)
        {
            string text = "数据库：" + dbName; //文档标题
            length = text.Trim().Length+2;
            Document document = this.WordApp.Documents.Add(ref template, ref template, ref template, ref template);
            this.SetPageHeader("CodeGenius");

            this.InsertText(text, 12f, 0x98967e, WdParagraphAlignment.wdAlignParagraphCenter); 
            //this.ToNextParagraph();
            //this.WordApp.Selection.MoveDown(); 
            this.WordApp.Selection.InsertBreak(ref type);
             this.WordApp.Selection.InsertBreak(ref type);   //插入空行 
            return document;
        }
        #endregion

        #region Word样式设置相关方法
        /// <summary>
        /// 添加页眉
        /// </summary>
        /// <param name="context">页眉内容</param>
        private void SetPageHeader(string context)
        {
            this.WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            this.WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            this.WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(context);
            this.WordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            this.WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;  //跳出页眉设置 
        }

        /// <summary>
        /// 在当前位置插入文字
        /// </summary>
        /// <param name="context">文字内容</param>
        /// <param name="fontSize">文字大小</param>
        /// <param name="fontBold">粗体</param>
        /// <param name="align">对齐方向</param>
        /// <param name="familyName">字体名称</param>
        /// <param name="fontColor">字体颜色</param>
        private void InsertText(string context, float fontSize, int fontBold, WdParagraphAlignment align, string familyName = null, WdColor fontColor = WdColor.wdColorBlack)
        {
            this.WordApp.Selection.Font.Size = fontSize;
            this.WordApp.Selection.Font.Bold = fontBold;
            this.WordApp.Selection.Font.Color = fontColor;
            if (!string.IsNullOrEmpty(familyName))
            {
                this.WordApp.Selection.Font.Name = familyName;
            }
            this.WordApp.Selection.ParagraphFormat.Alignment = align;
            this.WordApp.Selection.TypeText(context);
        }

        /// <summary>
        /// 翻页
        /// </summary>
        private void ToNextPage()
        {
            object breakPage = Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
            this.WordApp.Selection.InsertBreak(ref breakPage);
        }
        /// <summary>
        /// 焦点移动count段落
        /// </summary>
        /// <param name="count"></param>
        private void MoveParagraph(int count)
        {
            object _count = count;
            object wdP = WdUnits.wdParagraph;//换一段落
            this.WordApp.Selection.Move(ref wdP, ref _count);
        }
        /// <summary>
        /// 焦点移动count行
        /// </summary>
        /// <param name="count"></param>
        private void MoveRow(int count)
        {
            object _count = count;
            object WdLine = WdUnits.wdLine;//换一行
            this.WordApp.Selection.Move(ref WdLine, ref _count);
        }
        /// <summary>
        /// 焦点移动字符数
        /// </summary>
        /// <param name="count"></param>
        private void MoveCharacter(int count)
        {
            object _count = count;
            object wdCharacter = WdUnits.wdCharacter;
            this.WordApp.Selection.Move(ref wdCharacter, ref _count);
        }
        /// <summary>
        /// 插入段落
        /// </summary>
        private void ToNextParagraph()
        {
            this.WordApp.Selection.TypeParagraph();//插入段落
        }
        #endregion

        #region 创建WordTable
        /// <summary>
        /// 创建WordTable
        /// </summary>
        /// <param name="document"></param>
        /// <param name="tableTitle"></param>
        /// <returns></returns>
        private Table CreateWordTable(Document document, string tableTitle)
        { 
            Range range = document.Range(ref length, ref length);
            this.WordApp.Selection.Tables.Add(range, 1, 10, ref template, ref template);
            range.InsertBefore("表名：" + tableTitle); //表标题
            range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
           
            Table table = document.Tables[1];
            table.AllowAutoFit = true;
            //table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
            table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
            table.Borders.Enable = 1;
            table.Rows.Height = 15f;
            return table;
        }
        #endregion

        #region 填充WordTable相关方法
        /// <summary>
        /// 填充wordTable
        /// </summary>
        /// <param name="wordTable"></param>
        /// <param name="dataTable"></param>
        private void FillWordTable(Table wordTable, DataTable dataTable)
        {
            string strValue = string.Empty;
            this.AddTitleRowToWordTable(wordTable);
            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                this.AddRowToWordTable(wordTable, rowIndex + 2);  //wordTable行位置下标从1开始
                for (int colIndex = 1; colIndex <= wordTable.Columns.Count; colIndex++)
                { 
                    switch (colIndex)
                    {
                        case 1:
                            strValue = dataTable.Rows[rowIndex]["ColumnID"].ToString(); break;
                        case 2:
                            strValue = dataTable.Rows[rowIndex]["Name"].ToString(); break;
                        case 3:
                            strValue = dataTable.Rows[rowIndex]["DataType"].ToString(); break;
                        case 4:
                            strValue = dataTable.Rows[rowIndex]["MaxLength"].ToString(); break;
                        case 5:
                            strValue = dataTable.Rows[rowIndex]["Scale"].ToString(); break;
                        case 6:
                            strValue = (dataTable.Rows[rowIndex]["IsIdentity"].ToString() == "1") ? "是" : ""; break;
                        case 7:
                            strValue = TypeHelper.ToBoolean(dataTable.Rows[rowIndex]["IsPrimaryKey"]) ? "是" : ""; break;
                        case 8:
                            strValue = TypeHelper.ToBoolean(dataTable.Rows[rowIndex]["IsNullable"]) ? "是" : "否"; break;
                        case 9:
                            strValue = dataTable.Rows[rowIndex]["DefaultValue"].ToString().TrimStart('(').Replace("))",")"); break;
                        case 10:
                            strValue = dataTable.Rows[rowIndex]["Description"].ToString(); break;
                        default:
                            break;
                    }
                    wordTable.Cell(rowIndex + 2, colIndex).Range.Text = strValue;
                }
            }
        }

        /// <summary>
        /// 添加标题行
        /// </summary>
        /// <param name="wordTable"></param>
        private void AddTitleRowToWordTable(Table wordTable)
        {
            Range range2 = wordTable.Rows[1].Range;
            range2.Font.Size = 9f;
            range2.Font.Name = "宋体";
            range2.Font.Bold = 1;
            //for (int i = 1; i <= 10; i++)
            //{ 
            //    wordTable.Columns[i].Width = 33f;
            //}
            wordTable.Cell(1, 1).Range.Text = "序号";
            wordTable.Cell(1, 2).Range.Text = "列名";
            wordTable.Cell(1, 3).Range.Text = "类型";
            wordTable.Cell(1, 4).Range.Text = "长度";
            wordTable.Cell(1, 5).Range.Text = "小数位";
            wordTable.Cell(1, 6).Range.Text = "标识";
            wordTable.Cell(1, 7).Range.Text = "主键";
            wordTable.Cell(1, 8).Range.Text = "允许空";
            wordTable.Cell(1, 9).Range.Text = "默认值";
            wordTable.Cell(1, 10).Range.Text = "说明";
        }

        /// <summary>
        /// 为表添加行
        /// </summary>
        /// <param name="wordTable">要添加行的表</param>
        /// <param name="rowIndex">添加行的位置，从1开始</param>
        private void AddRowToWordTable(Table wordTable, int rowIndex)
        {
            object beforeRow = Type.Missing;
            wordTable.Rows.Add(ref beforeRow);
            //table.Rows[row].Range.Select();
            Range range3 = wordTable.Rows[rowIndex].Range;
            range3.Font.Size = 9f;
            range3.Font.Name = "宋体";
            range3.Font.Bold = 0;
            range3.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
        }
        #endregion 
        #endregion

    }
}
