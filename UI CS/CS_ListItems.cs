using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Eplan.MCNS.Lib.Share_CS;
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
    public class CS_ListItems
    {
        //ModelPage ComboBox List
        public List<string> listMODName { get; set; } = new List<string> 
        {
            "UC",
            "UCX",
            "PC",
            "SM",
        };
        public List<string> listMODOption { get; set; } = new List<string>
        {
            "C",
            "D",
            "D(v)",
            "M",
        };
        public List<string> listMSPinputVolt { get; set; } = new List<string>
        {
            "380V",
            "220V",
            "440V",
            "480V",
        };
        public List<string> listMSPinputHz { get; set; } = new List<string>
        {
            "60",
            "50",
        };
        public List<string> listMSPpanelSize { get; set; } = new List<string>
        {
            "800*500*1700",
            "1000*500*1700",
            "500*400*1500",
            "기타"
        };
        public List<string> listMSPcontroller { get; set; } = new List<string>
        {
            "HMX_MICOM",
            "MIT_R SERIES",
            "MIT_Q SERIES",
            "SIE_S7-1200 SERIES",
            "SIE_S7-1500 SERIES"
        };
        public List<string> listMSPinverter { get; set; } = new List<string>
        {
            "SEW_MODULER",
            "SEW_SYSTEM",
            "SIE_S120",
        };
        public List<string> listOPmachineControl { get; set; } = new List<string>
        {
            "터치패널(당사표준)",
            "팬던트(Proface)",
            "기타",
        };
        public List<string> listOPremoteControl { get; set; } = new List<string>
        {
            "독립(표준)",
            "통합",
        };
        public List<string> listOPemergencyPower { get; set; } = new List<string>
        {
            "trolley(표준)",
            "비접촉",
        };
        public List<string> listOPemergencyLocation { get; set; } = new List<string>
        {
            "하부",
            "상부",
        };
        //ELEQ ComboBox List
        public List<string> listEleqMccbModel { get; set; } = new List<string> 
        {
            "ABB(표준)",
            "LS",
            "슈나이더",
        };
        public List<string> listEleqSmpsModel { get; set; } = new List<string>
        {
            "바이드뮬러(표준)",
            "PULS",
            "민웰",
        };
        public List<string> listEleqCableModel { get; set; } = new List<string>
        {
            "이구스(표준)",
            "LAPP",
            "경신",
        };
        public List<string> listEleqHubModel { get; set; } = new List<string>
        {
            "MOXA(표준)",
            "피닉스컨택트",
            "SIEMENS",
        };
        public List<string> listEleqSensorType { get; set; } = new List<string>
        {
            "NPN",
            "PNP",
        };
        public List<string> listEleqModem { get; set; } = new List<string>
        {
            "8WF-11A/11B",
            "LS682-DA-E-PnF",
        };
        public List<string> listEleqInterLockSensorSide { get; set; } = new List<string>
        {
            "H/P 측",
            "O/P 측",
        };
        public List<string> listEleqInterLockBit { get; set; } = new List<string>
        {
            "8 BIT",
        };
        public List<string> listEleqNpnSensorItem { get; set; } = new List<string>
        {
            "DMS-HB1-N",
        };
        public List<string> listEleqPnpSensorItem { get; set; } = new List<string>
        {
            "DMS-HB1-N70",
        };
        //LIFT ComboBox List
        public List<string> listLiftMotorSpec { get; set; } = new List<string>
        {
            "유도기",
            "동기기",
            "서보모터",
        };
        public List<string> listLiftRaserAbsLocation { get; set; } = new List<string>
        {
            "DL100-21AA2101",
            "OMR150M-R1000-SSI-V1V1B",
        };
        public List<string> listLiftBarcodeAbsLocation { get; set; } = new List<string>
        {
        };
        public List<string> listLiftBrakeOption { get; set; } = new List<string>
        {
            "BMKB 1.5",
            "BMH 1.5",
        };
        public List<string> listLiftRopeTension { get; set; } = new List<string>
        {
            "i10-RA213",
            "D4N-2120",
        };
        public List<string> listLiftNpnSensorSide { get; set; } = new List<string>
        {
            "E3Z-G61",
            "OMP-A821",
        };
        public List<string> listLiftPnpSensorSide { get; set; } = new List<string>
        {
            "E3Z-G81",
            "OMP-A821P",
        };
        public List<string> listLiftSensorItem { get; set; } = new List<string>
        {
            
        };
        //TRAV ComboBox List
        public List<string> listTravMotorSpec { get; set; } = new List<string>
        {
            "유도기",
            "동기기",
            "서보모터",
        };
        public List<string> listTravRaserAbsLocation { get; set; } = new List<string>
        {
            "DL100-21AA2101",
            "OMR150M-R1000-SSI-V1V1B",
        };
        public List<string> listTravBarcodeAbsLocation { get; set; } = new List<string>
        {
            "BPS 307i SM 100D",
        };
        public List<string> listTravBrakeOption { get; set; } = new List<string>
        {
            "BMKB 1.5",
            "BMH 1.5",
        };
        public List<string> listTravNpnSensorSide { get; set; } = new List<string>
        {
            "E3Z-G61",
            "OMP-A821",
        };
        public List<string> listTravPnpSensorSide { get; set; } = new List<string>
        {
            "E3Z-G81",
            "OMP-A821P",
        };
        public List<string> listTravSensorItem { get; set; } = new List<string>
        {
        };
        //FORK1 ComboBox List
        public List<string> listForkMotorSpec { get; set; } = new List<string>
        {
            "유도기",
            "동기기",
            "서보모터",
        };
        public List<string> listForkMotorManufacturer { get; set; } = new List<string>
        {
            "HMX",
            "EURO",
            "LHD",
        };
        public List<string> listForkMotorMethod { get; set; } = new List<string>
        {
            "Y",
            "Δ",
        };
        public List<string> listForkAbsLocation { get; set; } = new List<string>
        {
        };
        public List<string> listForkBrakeOption { get; set; } = new List<string>
        {
            "BMKB 1.5",
            "BMH 1.5",
            "BMV5",
        };
        public List<string> listForkNpnRightPosition { get; set; } = new List<string>
        {
            "IFS700",
            "WL8-N2231",
            "GL6-N4212",
            "WLCA2-G",
            "D4MC-5020",
        };
        public List<string> listForkPnpRightPosition { get; set; } = new List<string>
        {
            "IFS703",
        };
        //CARR ComboBox List
        public List<string> listCarrNpnSensor { get; set; } = new List<string>
        {
            "BJR10M-TDT",
            "E3Z-T61",
            "MV100-RT",
        };
        public List<string> listCarrPnpSensor { get; set; } = new List<string>
        {
            "BJR10M-TDT-P",
            "E3Z-T81",
            "MV100-RT/103",
        };
        public List<string> listCarrNpnDoubleInput { get; set; } = new List<string>
        {
            "O5D-102",
        };
        public List<string> listCarrPnpDoubleInput { get; set; } = new List<string>
        {
            "O5D100",
        };



        public void SaveToXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CS_ListItems));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, this);  // this를 이용해 현재 객체를 직렬화
            }
        }

        public void LoadListFromXmlToComboBoxes(string xmlFilePath)
        {
            try
            {
                // XML 파일을 로드합니다.
                XDocument xDocument = XDocument.Load(xmlFilePath);

                // 각 리스트 요소를 탐색하여 매칭합니다.
                foreach (var listElement in xDocument.Root.Elements())
                {
                    // 리스트 이름을 가져옵니다.
                    string listName = listElement.Name.LocalName; // 예: listMODName, listMODOption 등

                    // 해당 리스트 속성을 찾아서 값을 추가합니다.
                    PropertyInfo propertyInfo = this.GetType().GetProperty(listName);
                    if (propertyInfo != null && propertyInfo.PropertyType == typeof(List<string>))
                    {
                        // 리스트를 비웁니다.
                        var targetList = (List<string>)propertyInfo.GetValue(this);
                        targetList.Clear(); // 기존 항목 삭제

                        // XML에서 새 항목을 추가합니다.
                        foreach (var item in listElement.Elements("item")) // <item> 요소를 지정합니다.
                        {
                            // <String> 요소의 값을 가져옵니다.
                            string stringValue = item.Element("String")?.Value;
                            if (!string.IsNullOrEmpty(stringValue)) // null 또는 빈 문자열이 아닐 경우에만 추가
                            {
                                targetList.Add(stringValue);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading XML: {ex.Message}");
            }
        }

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
