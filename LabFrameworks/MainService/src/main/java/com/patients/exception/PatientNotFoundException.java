package com.patients.exception;

public class PatientNotFoundException extends RuntimeException {

    public PatientNotFoundException(String name) {
        super(String.format("patient with Name %d not found", name));
    }

    public PatientNotFoundException(Long id) {
        super(String.format("patient with Id %d not found", id));
    }

}
