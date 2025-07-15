Feature: Register on Baasic Demo Site
This feature file frames the process of registering a new user on the Baasic Demo Site.
  In order to use the Baasic Demo Site.

@TC008 @Registration
  Scenario: Register with mismatched passwords
    Given I open the start page
    Then the 'Homepage' is displayed
    And the 'Logo' is displayed in the top left corner

    When I hover over the 'Logo'
    Then the 'Menu' dropdown is displayed

    When I click on the 'MENU' link
    Then the 'Menu' overlay is displayed

    When I click on the Register link
    Then the 'Register' page is displayed
    And the 'Logo' is displayed in the top left corner of the 'Register' page
    And the 'Contact add' logo is displayed
    And the 'Register' banner is displayed and contains 'Register' string
    And the 'Email' banner is displayed and contains 'Email' string
    And the 'Email' textbox is displayed, enabled, and empty
    And the 'Username' banner is displayed and contains 'Username' string
    And the 'Username' textbox is displayed, enabled and empty
    And the 'Password' banner is displayed and contains 'Password' string
    And the 'Password' textbox is displayed, enabled and empty
    And the 'Confirm password' banner is displayed and contains 'Confirm Password' string
    And the 'Confirm password' textbox is displayed, enabled, and empty
    And the 'Register' button is displayed and contains 'REGISTER' string

    When I enter 'tibor.weigand@gmail.com' into the 'Email' textbox
    Then the 'Email' textbox contains 'tibor.weigand@gmail.com' string

    When I enter 'tiborle' into the 'Username' textbox
    Then the 'Username' textbox contains 'tiborle' string

    When I enter 'elrobit' into the 'Password' textbox
    Then the 'Password' textbox contains an anonymized password

    When I enter 'elrobit123' into the 'Confirm Password' textbox
    Then the 'Confirm Password' textbox contains an anonymized password

    When I click on the Register button
    Then the error message 'Passwords do not match.' is displayed