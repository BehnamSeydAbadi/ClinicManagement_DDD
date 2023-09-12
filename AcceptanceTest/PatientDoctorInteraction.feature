Feature: PatientDoctorInteraction

Scenario: Schedule an appointment
	Given I am a patient
	And I want to schedule an appointment with a doctor
	When I provide my name, contact information, and preferred date and time
	Then the doctor should confirm the appointment
