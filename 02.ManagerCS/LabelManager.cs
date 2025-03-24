using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Eplan.MCNS.Lib
{
    /// <summary>
    /// 모든 라벨 객체 제어를 위한 클래스
    /// </summary>
    public class LabelManager
    {
        // 상태를 저장할 변수 선언
        private Dictionary<LabelControl, bool> hoverStates = new Dictionary<LabelControl, bool>();
        private Dictionary<LabelControl, bool> clickStates = new Dictionary<LabelControl, bool>();
        private LabelControl lastClickedLabel = null;

        public void HoverLabel(LabelControl lbl, Color hoverColor)
        {
            hoverStates[lbl] = false;
            clickStates[lbl] = false;

            // 라벨 마우스 호버 시 컬러 변경
            lbl.MouseHover += (sender, e) =>
            {
                if (!clickStates[lbl]) // 클릭된 상태가 아니면 호버 색상 적용
                {
                    hoverStates[lbl] = true;
                    lbl.ForeColor = hoverColor;
                    lbl.Invalidate();
                }
            };

            // 라벨 마우스 호버 해제 시 기본 색상 복귀
            lbl.MouseLeave += (sender, e) =>
            {
                hoverStates[lbl] = false;
                if (!clickStates[lbl]) // 클릭된 상태가 아니면 기본 색상으로 복귀
                {
                    lbl.ForeColor = ColorUtility.colors[Ecolor.TextBlack]; // 기본 색상
                    lbl.Invalidate();
                }
            };

            // 라벨 클릭 시 클릭 상태 유지
            lbl.Click += (sender, e) =>
            {
                ResetPreviousLabel(); // 이전에 클릭된 라벨의 상태 초기화
                clickStates[lbl] = true;
                lbl.ForeColor = hoverColor;
                lbl.Invalidate();
                lastClickedLabel = lbl; // 현재 클릭된 라벨을 저장
            };

        }

        private void ResetPreviousLabel()
        {
            // 이전에 클릭된 라벨이 있으면 해당 라벨의 클릭 상태 초기화
            if (lastClickedLabel != null)
            {
                clickStates[lastClickedLabel] = false;
                lastClickedLabel.ForeColor = ColorUtility.colors[Ecolor.TextBlack]; // 기본 색상
                lastClickedLabel.Invalidate();
            }
        }

    }
}
