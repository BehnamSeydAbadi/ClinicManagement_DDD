Feature: Patient doctor interaction

Scenario: Schedule an appointment
	Given I am a patient
	And I want to schedule an appointment with a doctor
	When I provide my name, contact information, and preferred date and time
	Then the appointment should be scheduled

Scenario: Doctor confirms the appointment
	Given I am a doctor
	And I have received an appointment request from a patient
	When I confirm the appointment with the patient
	Then I see the appointment as confirmed 
