Feature: CustomerAPI
	Create customer from CRM API

@mytag
Scenario: Create CRM Customer from API
	Given Create Customer Data
	When Post Customer Data
	Then It should be successfully created

