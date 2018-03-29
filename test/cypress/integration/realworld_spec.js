describe('Home page', function () {
    it("Opens an article", function () {
        cy.visit('/')
        cy.get('.article-preview h1').first().then(($title) => {
            // Find title of first article
            const title = $title.text()

            // Click on it
            $title.click()

            // Verify that we find the article title on the new page
            cy.contains(title)
        })
    })

    it("Selects a tag", function () {
        cy.visit('/')

        // Click first tag pill
        cy.get('.sidebar .tag-pill').first().click()

        cy.get('.sidebar .tag-pill').first().then(($tagPill) => {
            // Find value of first tag pill
            const tag = $tagPill.text()

            // Verify that we find the tag hash on the new page
            cy.get('.ion-pound').parents().first().contains(tag)
        })
    })
})

describe('Sign up', function () {
    it("Shows error messages", function () {
        cy.visit('/')
        cy.contains('Sign up').click()
        cy.get('[type=submit]').click()
        cy.contains("can't be blank")
    })
})

describe('Sign in', function () {
    it("Logs in", function () {
        cy.visit('/')
        cy.contains('Sign in').click()
        cy.get('[type=email]').type(Cypress.env('email'))
        cy.get('[type=password]').type(Cypress.env('password'))
        cy.get('[type=submit]').click()

        // Verify we're back on the Home page
        cy.contains("Read more")
    })
})

describe('Editor', function () {
    it("Submits an article", function () {
        cy.visit('/')

        // Sign in
        cy.contains('Sign in').click()
        cy.get('[type=email]').type(Cypress.env('email'))
        cy.get('[type=password]').type(Cypress.env('password'))
        cy.get('[type=submit]').click()

        // Submit article
        cy.contains("New Post").click()
        cy.get('input').eq(0).type('Blazor Realworld Test Suite')
        cy.get('input').eq(1).type('Description')
        cy.get('input').eq(2).type('testing blazor')
        cy.get('textarea').first().type('Article body')
        cy.contains('Publish Article').click()

        // Delete article
        cy.contains("Delete Article").click()

        // Verify we're back on the Home page
        cy.contains("Global Feed")
    })
})
