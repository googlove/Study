package com.patients.controller;

import com.patients.model.Patient;
import com.patients.service.IPatientService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController @RequestMapping(value = "/patients")
public class PatientController {

	@Autowired
	IPatientService patientService;

	@GetMapping()
	@ResponseStatus(HttpStatus.OK)
	public List<Patient> findAll() {
		return patientService.findAll();
	}

	@GetMapping(value = "/{id}")
	public Patient getPatient(@PathVariable(value="id") Long id) {
		return patientService.findById(id);
	}

	@PostMapping(consumes = MediaType.APPLICATION_JSON_VALUE, produces = MediaType.APPLICATION_JSON_VALUE)
	public Patient createPatient(@PathVariable(value="id") Patient patient) {
		return patientService.save(patient);
	}

	@DeleteMapping(value = "/{id}")
	public Patient deletePatient(@PathVariable(value="id") Long id) {
		return patientService.remove(getPatient(id));
	}

}
