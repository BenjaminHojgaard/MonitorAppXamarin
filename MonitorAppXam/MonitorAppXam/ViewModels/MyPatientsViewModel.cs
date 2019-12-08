using MonitorAppXam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MonitorAppXam.ViewModels
{
    public class MyPatientsViewModel
    {
        public ObservableCollection<PatientInfo> MyPatients { get; set; }

        public MyPatientsViewModel()
        {
            FetchPatients();
        }

        public void FetchPatients()
        {
            MyPatients = new ObservableCollection<PatientInfo>();
            ObservableCollection<PatientData> data = new ObservableCollection<PatientData>
            {
                new PatientData() { SpO2 = 96, O2 = 1, Pulse = 80 },
                new PatientData() { SpO2 = 97, O2 = 2, Pulse = 82 },
                new PatientData() { SpO2 = 98, O2 = 2, Pulse = 84 },
                new PatientData() { SpO2 = 98, O2 = 2, Pulse = 82 },
                new PatientData() { SpO2 = 98, O2 = 1, Pulse = 84 },
                new PatientData() { SpO2 = 97, O2 = 1, Pulse = 86 }
            };

            MyPatients.Add(new PatientInfo { FirstName = "Kirsten", PatientID = 1, LastMeasurement = DateTime.Now, Notes = "Lorem Ipsum", PatientVitalsData = new ObservableCollection<PatientData>(data) });
            MyPatients.Add(new PatientInfo { FirstName = "Thomas", PatientID = 2, LastMeasurement = DateTime.Now, Notes = "Lorem Ipsum", PatientVitalsData = new ObservableCollection<PatientData>(data) });
            MyPatients.Add(new PatientInfo { FirstName = "Peter", PatientID = 3, LastMeasurement = DateTime.Now, Notes = "Lorem Ipsum", PatientVitalsData = new ObservableCollection<PatientData>(data) });
            MyPatients.Add(new PatientInfo { FirstName = "Jens", PatientID = 4, LastMeasurement = DateTime.Now, Notes = "Lorem Ipsum", PatientVitalsData = new ObservableCollection<PatientData>(data) });
            MyPatients.Add(new PatientInfo { FirstName = "Gitte", PatientID = 5, LastMeasurement = DateTime.Now, Notes = "Lorem Ipsum", PatientVitalsData = new ObservableCollection<PatientData>(data) });
            MyPatients.Add(new PatientInfo { FirstName = "Lise", PatientID = 6, LastMeasurement = DateTime.Now, Notes = "Lorem Ipsum", PatientVitalsData = new ObservableCollection<PatientData>(data) });
        }
    }
}
