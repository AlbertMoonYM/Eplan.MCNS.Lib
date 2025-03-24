using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Eplan.MCNS.Lib
{
    public class FilePathManager
    {
        public void LoadListFromXmlToComboBox(string xmlFilePath, string listName, ComboBoxEdit cb)
        {
            cb.Properties.Items.Clear();
            //cb.Properties.Items.Clear();
            cb.SelectedIndex = -1;
            // XML 파일을 읽고 파싱
            XElement xml = XElement.Load(xmlFilePath);

            // listName의 String 값을 추출하여 cb에 추가
            var modNames = xml.Descendants(listName)
                              .Elements("item")
                              .Select(item => item.Element("String")?.Value)
                              .Where(value => value != null)  // null 체크 추가
                              .ToArray();

            // ComboBoxEdit에 중복 없이 항목을 추가
            foreach (var modName in modNames)
            {
                if (!cb.Properties.Items.Contains(modName))  // 중복 항목이 없으면 추가
                {
                    cb.Properties.Items.Add(modName);
                }
            }

        }
        public void LoadListFromXmlToDataTable(string filePath, string listName, GridControl gc)
        {
            // XML 파일 로드
            XDocument xmlDoc = XDocument.Load(filePath);

            // DataTable 생성 및 열 추가
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));       // 번호 열
            dt.Columns.Add("String", typeof(string)); // 모듈 이름 열
            dt.Columns.Add("Description1", typeof(string));
            dt.Columns.Add("Description2", typeof(string));

            // XML에서 listMODName 데이터를 추출하여 데이터 테이블에 추가합니다.
            var modNameElements = xmlDoc.Descendants(listName).Elements("item"); // <item> 요소를 가져옴

            int counter = 1;  // 번호를 위한 카운터

            foreach (var element in modNameElements)
            {
                DataRow row = dt.NewRow();
                row["No"] = counter;                           // 번호 추가
                row["String"] = element.Element("String")?.Value; // 모듈 이름 추가
                row["Description1"] = element.Element("Description1")?.Value; // 설명 1 추가
                row["Description2"] = element.Element("Description2")?.Value; // 설명 2 추가
                dt.Rows.Add(row);
                counter++;  // 번호 증가
            }

            // 빈 행 추가: XML 항목 수 + 20칸
            int additionalRows = 20; // 추가할 빈 행 수
            for (int i = 0; i < additionalRows; i++)
            {
                DataRow emptyRow = dt.NewRow();
                emptyRow["No"] = counter; // 번호 추가
                dt.Rows.Add(emptyRow);
                counter++;
            }

            // GridControl에 DataTable 바인딩
            gc.DataSource = dt;
        }

        public void SaveListFromDataTableToXml(string filePath, string listName, GridControl gc)
        {
            // 기존 XML 파일 로드
            XDocument xDocument;
            try
            {
                xDocument = XDocument.Load(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"XML 파일 로드 중 오류 발생: {ex.Message}");
                return; // 오류가 발생하면 저장을 중단
            }

            // listMODName 요소 가져오기 또는 새로 생성
            XElement listMODNameElement = xDocument.Root.Element(listName);
            if (listMODNameElement == null)
            {
                listMODNameElement = new XElement(listName);
                xDocument.Root.Add(listMODNameElement);
            }
            else
            {
                // 기존 요소 제거하여 새로운 데이터를 추가할 수 있도록 준비
                listMODNameElement.RemoveAll();
            }

            // DataTable의 각 행을 탐색
            foreach (DataRow row in ((DataTable)gc.DataSource).Rows)
            {
                // 문자열이 비어있지 않은 경우에만 저장
                if (!string.IsNullOrEmpty(row["String"]?.ToString()))
                {
                    // <item> 요소 생성
                    XElement itemElement = new XElement("item",
                        new XElement("No", row["No"]),
                        new XElement("String", row["String"]),
                        new XElement("Description1", row["Description1"]),
                        new XElement("Description2", row["Description2"])
                    );

                    // listMODName 요소에 item 추가
                    listMODNameElement.Add(itemElement);
                }
            }

            // XML 파일 저장
            try
            {
                xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"XML 파일 저장 중 오류 발생: {ex.Message}");
            }
        }

    }
}
