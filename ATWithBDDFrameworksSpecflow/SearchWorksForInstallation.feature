Feature: SearchWorksForInstallation

In order to get help installing specflow
As a specflow`s site visitor
I want to be able to search for the installation doc on it`s documentation page

@installationdocsearch
Scenario: Search for installation doc
	Given I opened Docs page for the SpecFlow on the specflow`s site
	When I Search for the 'Installation'
	Then The page opened has title 'Installation'
