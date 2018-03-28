describe('Home page', function () {
    it("Verifies that the home page loads", function () {
        cy.visit('https://react-redux.realworld.io')

        cy.contains('Read more')
    })
})