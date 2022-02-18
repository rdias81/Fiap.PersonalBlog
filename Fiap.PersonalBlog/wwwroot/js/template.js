define([], function () {

    function generateBlogItem(item) {
        let template = $('#blog-card').html();
        template = template.replace('{{PostId}}', item.postId);
        template = template.replace('{{Title}}', item.title);
        template = template.replace('{{ShortDescription}}', item.shortDescription);
        template = template.replace('{{Link}}', item.link);

        return template;
    }

    function appendBlogList(items) {
        let cardHtml = '';
        for (let i = 0; i < items.length; i++) {
            cardHtml += generateBlogItem(items[i]);
        }

        $('#blog-list').append(cardHtml);
    }

    return {
        appendBlogList: appendBlogList
    }
});