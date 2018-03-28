describe('Home page', function () {
    it("Verifies that the home page loads", function () {
        cy.visit('/')

        cy.contains('Read more')
    })
})