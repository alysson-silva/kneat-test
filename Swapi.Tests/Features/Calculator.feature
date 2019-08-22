Feature: Resupply calculator
  As a spaceship captain, in order to avoid mutiny
  I need to know how many times I need to stop
  and resupply my ship before my crew starves to death.

  Scenario: Listing of all starships and their number of stops necessary
    Given I have a desire to know how many stops all starships have to make in a flight of 1000000 MGLT
    When I press enter
    Then the calculator must list all spaceships and their number of stops before depleting all consumables like this:
      | Name                          | Stops   |
      | Millennium Falcon             | 9       |
      | Y-wing                        | 74      |
      | Rebel transport               | 11      |
