class ArtGallery{
    constructor(creator){
        this.creator = creator;
        this.possibleArticles = {
            "picture":200,
            "photo":50,
            "item":250
        }
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle( articleModel, articleName, quantity ){
        articleModel = articleModel.toLowerCase();
        if(!this.possibleArticles.hasOwnProperty(articleModel)){
            throw new Error("This article model is not included in this gallery!");
        }

        let artical = this.listOfArticles.find(x => x.articleName == articleName);

        if(artical != undefined && artical.articleModel == articleModel){
            artical.quantity += quantity;
        }else{
            this.listOfArticles.push({
                articleModel: articleModel,
                articleName: articleName,
                quantity: quantity
            });

        }
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest ( guestName, personality){
        if(this.guests.some(x => x.guestName == guestName)){
            throw new Error(`${guestName} has already been invited.`);
        }

        let points = 0;
        if(personality == 'Vip'){
            points = 500;
        }else if(personality == 'Middle'){
            points = 250;
        }else{
            points = 50;
        }

        this.guests.push({
            guestName: guestName,
            points: points,
            purchaseArticle: 0
        })

        return `You have successfully invited ${guestName}!`

    }

    buyArticle ( articleModel, articleName, guestName){
        if(!this.listOfArticles.some(x => x.articleName == articleName)
        || !this.possibleArticles.hasOwnProperty(articleModel)){
            throw new Error("This article is not found.");
        }

        let artical = this.listOfArticles.find(x => x.articleName == articleName);

        if(artical.quantity == 0){
            return `The ${articleName} is not available.`
        }

        if(!this.guests.some(x => x.guestName == guestName)){
            return "This guest is not invited.";
        }

        let guest = this.guests.find(x => x.guestName == guestName);

        if(guest.points < this.possibleArticles[artical.articleModel]){
            return "You need to more points to purchase the article.";
        }else{
            guest.points -= this.possibleArticles[artical.articleModel];
            guest.purchaseArticle++;
            artical.quantity--;
        }

        return `${guestName} successfully purchased the article worth ${this.possibleArticles[artical.articleModel]} points.`;

    }

    showGalleryInfo (criteria){
        let output = [];
        if(criteria == 'article'){
            output.push("Articles information:");
            this.listOfArticles.forEach(x => {
                output.push(`${x.articleModel} - ${x.articleName} - ${x.quantity}`);
            })
        }else if (criteria == 'guest'){
            output.push("Guests information:");
            this.guests.forEach(x => {
                output.push(`${x.guestName} - ${x.purchaseArticle}`);
            })
        }

        return output.join('\n');
    }


}

const artGallery = new ArtGallery('Curtis Mayfield');
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John'));
console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter'));
console.log(artGallery.buyArticle('item', 'Mona Liza', 'John'));





// `Articles information:
// picture - Mona Liza - 3
// item - Ancient vase - 1`;






