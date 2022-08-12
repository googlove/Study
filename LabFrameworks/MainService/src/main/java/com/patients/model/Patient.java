package com.patients.model;

import javax.persistence.*;
import javax.validation.constraints.NotNull;
import java.util.Date;

@Entity
@Table(name = "PATIENTS")
public class Patient {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    @Column(name= "FIRSTNAME", length = 50)
    @NotNull(message = "FirstName is mandatory")
    private String firstName;
    @Column(name= "LASTNAME", length = 50)
    @NotNull(message = "LastName is mandatory")
    private String lastName;
    @Column(name= "DATEOFBIRTH")
    @NotNull(message = "DateOfBirth is mandatory")
    private Date dateOfBirth;

    public Patient() {}

    public Patient(long id, String firstName, String lastName, Date dataOfBirth) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dataOfBirth;
    }

    public long getId() {
        return id;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public Date getDateOfBirth() {
        return dateOfBirth;
    }
}
