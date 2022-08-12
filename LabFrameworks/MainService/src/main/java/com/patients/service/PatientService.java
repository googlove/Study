package com.patients.service;

import com.patients.exception.NoDataFoundException;
import com.patients.exception.PatientNotFoundException;
import com.patients.model.Patient;
import com.patients.repository.PatientRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PatientService implements IPatientService {

    @Autowired
    private PatientRepository patientRepository;

    @Override
    public Patient findById(Long id) {
        return patientRepository.findById(id).orElseThrow(() -> new PatientNotFoundException(id));
    }

    @Override
    public Patient save(Patient patient) {
        return patientRepository.save(patient);
    }

    @Override
    public Patient remove(Patient pat) {
        patientRepository.delete(pat);
        return pat;
    }

    @Override
    public List<Patient> findAll() {
        List patients = (List<Patient>) patientRepository.findAll();

        if (patients.isEmpty()) {
            throw new NoDataFoundException();
        }

        return patients;
    }
}
