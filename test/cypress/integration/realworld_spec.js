/// <reference types="Cypress" />

const apiUrl = Cypress.env('apiUrl')
const email = Cypress.env('email')
const password = Cypress.env('password')
const username = Cypress.env('username')
const token = Cypress.env('token')

function post(urlFragment, body) {
    return cy.request({
        "method": "POST",
        "url": `${apiUrl}${urlFragment}`,
        "headers": { "Authorization": `Token ${token}` },
        "body": body
    })
}

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
        cy.get('[type=email]').type(email)
        cy.get('[type=password]').type(password)
        cy.get('[type=submit]').click()

        // Verify we're back on the Home page
        cy.contains("Read more")
    })
})

describe('Secured operations', function () {
    beforeEach(function () {
        // Sign in
        window.localStorage.setItem('jwt', token);
    })

    describe('Editor', function () {
        it("Submits an article", function () {
            cy.visit('/')

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

    describe('Profile', function () {
        it("Shows my name and articles", function () {
            post('/articles', {
                "article": { "title": "Blazor test article", "description": "Description", "body": "Body", "tagList": ["blazor", "testing"] }
            })
                .then((response) => {
                    const slug = response.body.article.slug

                    cy.visit('/')

                    // Wait until logged in
                    cy.get(':nth-child(4) > .nav-link')

                    // Go to profile
                    cy.get('.nav').contains(username).click()
                    cy.get('.user-info').contains(username)
                    cy.contains('Blazor test article').click({ force: true })

                    // Delete article
                    cy.contains("Delete Article").click()
                })
        })
    })
})
