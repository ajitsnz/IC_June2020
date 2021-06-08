Feature: CustomerAPI
	customer from CRM API

Scenario: Create CRM Customer from API
	Given Create Customer Data
	When Post Customer Data
	Then It should be successfully created

Scenario: Delete CRM Customer from API
	Given Create Customer Data
	When Delete Customer
	Then It should be successfully Delete

Scenario: Update CRM Customer from API
	Given Create Customer Data
	When Update Customer
	Then It should be successfully updated

