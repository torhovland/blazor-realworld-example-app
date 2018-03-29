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
