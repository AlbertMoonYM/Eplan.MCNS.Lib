using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridView = DevExpress.XtraGrid.Views.Grid.GridView;

namespace Eplan.MCNS.Lib
{
    public class GridViewManager
    {
        /// <summary>
        /// DataTable을 기준으로 DataGrid 생성
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="gridView"></param>
        /// <param name="dataTable"></param>
        public void SetGridView(GridView gv)
        {
            
            // GridView 설정: 분류 그룹화
            gv.ClearSorting();
            gv.ClearGrouping();
            gv.Columns["Num"].Visible = false;
            gv.Columns["PageName"].Visible = false;
            gv.Columns["Function"].Visible = false;
            gv.Columns["ObjetType"].Visible = false;
            gv.Columns["Group"].GroupIndex = 0;
            gv.OptionsView.ShowGroupPanel = true;

            // GridView 설정: 기본 옵션 설정
            gv.Appearance.Row.Font = new Font("맑은 고딕", 9, FontStyle.Regular);
            gv.Appearance.HeaderPanel.Font = new Font("맑은 고딕", 9, FontStyle.Regular);
            gv.Appearance.FooterPanel.Font = new Font("맑은 고딕", 9, FontStyle.Regular);
            gv.Appearance.GroupPanel.Font = new Font("맑은 고딕", 9, FontStyle.Regular);
            gv.Appearance.GroupRow.Font = new Font("맑은 고딕", 9, FontStyle.Regular);
            gv.Appearance.Empty.BackColor = Color.Gray;
            gv.Appearance.GroupRow.BackColor = Color.LightGoldenrodYellow;

            // GridView 설정: 기본 설정 제한
            gv.OptionsView.ShowIndicator = false;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsCustomization.AllowColumnMoving = false;
            gv.OptionsBehavior.Editable = true;
            gv.Columns["Num"].OptionsColumn.AllowEdit = false;
            gv.Columns["PageName"].OptionsColumn.AllowEdit = false;
            gv.Columns["Function"].OptionsColumn.AllowEdit = false;
            gv.Columns["Group"].OptionsColumn.AllowEdit = false;
            gv.Columns["Item"].OptionsColumn.AllowEdit = false;
            gv.Columns["Data"].OptionsColumn.AllowEdit = false;
            gv.Columns["ObjetType"].OptionsColumn.AllowEdit = false;

            

            // 열의 너비를 내용에 맞게 조정
            gv.BestFitColumns();

            // 특정 열을 고정 너비로 설정
            gv.Columns["Item"].BestFit();
            gv.Columns["Item"].OptionsColumn.FixedWidth = true;
            // GridView 설정: 모든 그룹 확장
            if (gv.RowCount > 0) // 그룹이 존재할 경우에만 확장
            {
                gv.ExpandAllGroups();
            }

        }
        
        public void SetItemListGridView(GridView gv)
        {
            // GridView 설정: 분류 그룹화
            gv.ClearSorting();
            gv.ClearGrouping();
            gv.Columns[0].Visible = true;
            gv.Columns[1].Visible = true;
            gv.Columns[2].Visible = true;
            gv.Columns[3].Visible = true;

            // GridView 설정: 기본 옵션 설정
            gv.Appearance.Row.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.HeaderPanel.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.FooterPanel.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.GroupPanel.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.GroupRow.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.Empty.BackColor = Color.White;
            gv.Appearance.GroupRow.BackColor = Color.LightGoldenrodYellow;

            // GridView 설정: 기본 설정 제한
            gv.OptionsSelection.EnableAppearanceFocusedCell = false; 
            gv.OptionsSelection.EnableAppearanceFocusedRow = false;  
            gv.OptionsView.ShowIndicator = false;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsCustomization.AllowColumnMoving = false;
            gv.OptionsCustomization.AllowSort = false;
            //gv.OptionsBehavior.Editable = false;
            gv.OptionsSelection.MultiSelect = false;
            gv.Columns[0].OptionsColumn.AllowEdit = false;
            gv.Columns[1].OptionsColumn.AllowEdit = true;
            gv.Columns[2].OptionsColumn.AllowEdit = true;
            gv.Columns[3].OptionsColumn.AllowEdit = true;
            
            // 열의 너비를 내용에 맞게 조정
            gv.BestFitColumns();
            gv.Columns[0].Width = 40;
            gv.Columns[0].OptionsColumn.FixedWidth = true;
            gv.Columns[1].BestFit();
        }
        public void SetLoutCargo(GridView gv)
        {
            Font gridFont = new Font("맑은 고딕", 9, FontStyle.Regular);

            gv.Appearance.Row.Font = gridFont;
            gv.Appearance.HeaderPanel.Font = gridFont;
            gv.Appearance.FooterPanel.Font = gridFont;
            gv.Appearance.GroupPanel.Font = gridFont;
            gv.Appearance.GroupRow.Font = gridFont;

            gv.Appearance.Empty.BackColor = Color.Gray;
            gv.Appearance.GroupRow.BackColor = Color.LightGoldenrodYellow;

            gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsView.ShowIndicator = false;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsView.ShowAutoFilterRow = false;
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsCustomization.AllowFilter = false;
            gv.OptionsCustomization.AllowColumnMoving = false;
            gv.OptionsCustomization.AllowSort = false;
            gv.OptionsBehavior.Editable = true; // Edit mode 활성화
            
            // 숫자만 입력 가능한 RepositoryItemTextEdit 생성
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit numericEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            numericEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            numericEdit.Mask.EditMask = "n0";  // 정수만 입력 가능
            numericEdit.Mask.UseMaskAsDisplayFormat = true;

            gv.Columns["Width"].ColumnEdit = numericEdit;
            gv.Columns["Height"].ColumnEdit = numericEdit;
            gv.Columns["Depth"].ColumnEdit = numericEdit;

            gv.Columns["Items"].OptionsColumn.AllowEdit = false;
            // CustomRowCellEdit 이벤트 핸들러 추가
            gv.CustomRowCellEdit += (sender, e) =>
            {
                GridView view = sender as GridView;

                // 첫 번째 행 제외 (두 번째부터 검사)
                if (e.RowHandle > 0)
                {
                    bool isPreviousRowComplete = IsRowComplete(view, e.RowHandle - 1); // 이전 행이 모두 작성되었는지 확인

                    if (!isPreviousRowComplete)
                    {
                        // 이전 행이 작성되지 않았다면 1열을 제외한 나머지 셀 값을 모두 null로 설정하여 공란으로 만듬
                        for (int i = 1; i < view.Columns.Count; i++)  // 1열을 제외하고 (i = 1부터 시작)
                        {
                            view.SetRowCellValue(e.RowHandle, view.Columns[i], null); // 해당 행의 모든 셀 값을 null로 설정
                        }
                    }
                }
            };

            // RowCellStyle 이벤트 핸들러 추가
            gv.RowCellStyle += (sender, e) =>
            {
                GridView view = sender as GridView;

                // 첫 번째 행을 제외하고 비활성화된 행의 배경색을 회색으로 설정
                if (e.RowHandle > 0 && !IsRowComplete(view, e.RowHandle - 1))
                {
                    e.Appearance.BackColor = Color.LightGray; // 비활성화된 행 회색으로
                }
                else if (e.RowHandle == 0) // 첫 번째 행은 기본 색상 유지
                {
                    e.Appearance.BackColor = Color.White; // 또는 기본 색상으로 설정
                }
            };
        }
        public void SetIoGridView(GridView gv)
        {

            // GridView 설정: 분류 그룹화
            gv.ClearSorting();
            gv.ClearGrouping();
            gv.Columns["기능"].Visible = true;
            gv.Columns["LOCATION"].Visible = true;
            gv.Columns["DT"].Visible = true;
            gv.Columns["ADD."].Visible = true;
            gv.Columns["SIGNAL"].Visible = true;
            gv.Columns["DESCRIPTION"].Visible = true;
            //gv.Columns["LOCATION"].GroupIndex = 0;
            //gv.Columns["TYPE1"].GroupIndex = 1;
            //gv.Columns["PARTS"].GroupIndex = 2;
            //gv.Columns["DT"].GroupIndex = 3;
            gv.OptionsView.ShowGroupPanel = true;

            // GridView 설정: 기본 옵션 설정
            gv.Appearance.Row.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.HeaderPanel.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.FooterPanel.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.GroupPanel.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.GroupRow.Font = new Font("맑은 고딕", 10, FontStyle.Regular);
            gv.Appearance.Empty.BackColor = Color.Gray;
            gv.Appearance.GroupRow.BackColor = Color.LightGoldenrodYellow;

            // GridView 설정: 기본 설정 제한
            gv.OptionsView.ShowIndicator = false;
            gv.OptionsView.ShowGroupPanel = false;
            gv.OptionsCustomization.AllowGroup = false;
            gv.OptionsCustomization.AllowColumnMoving = false;
            gv.OptionsBehavior.Editable = true;
            gv.Columns["기능"].OptionsColumn.AllowEdit = true;
            gv.Columns["LOCATION"].OptionsColumn.AllowEdit = true;
            gv.Columns["DT"].OptionsColumn.AllowEdit = true;
            gv.Columns["ADD."].OptionsColumn.AllowEdit = true;
            gv.Columns["SIGNAL"].OptionsColumn.AllowEdit = true;
            gv.Columns["DESCRIPTION"].OptionsColumn.AllowEdit = true;
            gv.Columns["센서"].OptionsColumn.AllowEdit = true;
            gv.Columns["구분"].Visible = false;
            gv.Columns["포함조건"].Visible = false;
            gv.Columns["제외조건"].Visible = false;

            // "기능" 열을 콤보박스로 설정 (아이템 선택 전용)
            var cbFunc = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            var cbType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            var cbSensor = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            cbFunc.Items.AddRange(new[] { "ELEQ", "LIFT", "TRAV", "TRAV2", "FORK", "FORK2", "CARR" });
            cbType.Items.AddRange(new[] { "AUX-C", "PHO-G", "PHO-T", "LIM-S", "PRO-X", "PHO-D" });
            cbSensor.Items.AddRange(new[] { "정위치 센서", "리미트스위치", "화물 센서", "이중 입고"});
            cbFunc.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor; // 입력 비활성화
            cbType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor; // 입력 비활성화
            cbSensor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor; // 입력 비활성화
            gv.Columns["기능"].ColumnEdit = cbFunc;
            gv.Columns["타입"].ColumnEdit = cbType;
            gv.Columns["센서"].ColumnEdit = cbSensor;

            // 열의 너비를 내용에 맞게 조정
            gv.BestFitColumns();

            // GridView 설정: 모든 그룹 확장
            if (gv.RowCount > 0) // 그룹이 존재할 경우에만 확장
            {
                gv.ExpandAllGroups();
            }

        }


        private bool IsRowComplete(GridView view, int rowHandle)
        {
            var width = view.GetRowCellValue(rowHandle, "Width");
            var height = view.GetRowCellValue(rowHandle, "Height");
            var depth = view.GetRowCellValue(rowHandle, "Depth");

            return width != null && height != null && depth != null &&
                   !string.IsNullOrEmpty(width.ToString()) &&
                   !string.IsNullOrEmpty(height.ToString()) &&
                   !string.IsNullOrEmpty(depth.ToString());
        }
    }
}
