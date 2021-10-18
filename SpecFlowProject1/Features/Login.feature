Feature: Login
	As a user
	I want to signin in my account
	In order to do my thing


Scenario: Sigin with a valid user will succeed
	Given The user entered login page
	And The user typed the credentials: user "zedoingresso@hotmail.com" pass "zedoingresso@hotmail.com"
	When Press login button
	Then The user should be logged as: "Zé do Ingresso"
	And The user should be redirected to user dashboard page

Scenario: Try to sigin with a invalid user will fail
	Given The user entered login page
	And The user typed the credentials: user "blabla@blablabla.com.br" pass "64asd56as4d5"
	When Press login button
	Then Message "* Usuário ou senha incorretos." should be shown
