using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MonitorAppXam.Models
{
    public class PatientInfo
    {
        public string FirstName { get; set; }
        public int PatientID { get; set; }
        public DateTime LastMeasurement { get; set; }
        public string Notes { get; set; }
        public ObservableCollection<PatientData> PatientVitalsData { get; set; }
    }
}
