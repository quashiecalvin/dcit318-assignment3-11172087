using System;
using System.Collections.Generic;
using Models;
using Repository;

public class HealthSystemApp
{
    private Repository<Patient> _patientRepo = new Repository<Patient>();
    private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
    private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

    public void SeedData()
    {
        // Add patients
        _patientRepo.Add(new Patient(1, "Belinda Ewusi", 23, "Female"));
        _patientRepo.Add(new Patient(2, "Paul Ammah", 45, "Male"));
        _patientRepo.Add(new Patient(3, "Nelson Soh", 21, "Male"));

        // Add prescriptions
        _prescriptionRepo.Add(new Prescription(101, 1, "Paracetamol", new DateTime(2025, 7, 1)));
        _prescriptionRepo.Add(new Prescription(102, 1, "Cough Syrup", new DateTime(2025, 7, 2)));
        _prescriptionRepo.Add(new Prescription(103, 2, "Amoxicillin", new DateTime(2025, 7, 3)));
        _prescriptionRepo.Add(new Prescription(104, 3, "Ibuprofen", new DateTime(2025, 7, 4)));
        _prescriptionRepo.Add(new Prescription(105, 2, "Vitamin C", new DateTime(2025, 7, 5)));
    }

    public void BuildPrescriptionMap()
    {
        foreach (var prescription in _prescriptionRepo.GetAll())
        {
            if (!_prescriptionMap.ContainsKey(prescription.PatientId))
            {
                _prescriptionMap[prescription.PatientId] = new List<Prescription>();
            }
            _prescriptionMap[prescription.PatientId].Add(prescription);
        }
    }

    public void PrintAllPatients()
    {
        Console.WriteLine("=== Patients ===");
        foreach (var patient in _patientRepo.GetAll())
        {
            Console.WriteLine(patient);
        }
        Console.WriteLine();
    }

    public void PrintPrescriptionsForPatient(int id)
    {
        Console.WriteLine($"=== Prescriptions for Patient ID: {id} ===");

        if (_prescriptionMap.TryGetValue(id, out var prescriptions))
        {
            foreach (var p in prescriptions)
            {
                Console.WriteLine(p);
            }
        }
        else
        {
            Console.WriteLine("No prescriptions found.");
        }

        Console.WriteLine();
    }
}
