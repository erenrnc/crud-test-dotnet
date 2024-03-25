﻿Feature: customers API
    As a customer of the API
    I want to be able to retrieve and add customers

Scenario: Add a customer
    Given the API is running
    When I add a customer with the name "John Doe"
    Then the customer "John Doe" should be added

Scenario: Retrieve customers
    Given the API is running
    When I retrieve the list of customers
    Then the list should contain the customer "John Doe"