package com.patients.service;

import com.patients.model.Patient;

import java.util.List;

public interface IPatientService {

    Patient findById(Long id);
    Patient save(Patient pat);
    Patient remove(Patient pat);
    List<Patient> findAll();

}
