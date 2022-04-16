let { Repository } = require("./solution.js");
let expect = require('chai').expect;

describe("Tests Repository", function () {
    let repo = {};
    beforeEach(() => repo = new Repository({
        name: "string",
        age: "number",
        birthday: "object"
    }))
    describe("Test constructor", function () {

        it("TODO …", function () {
            
        });
    });
    // TODO: …
});
