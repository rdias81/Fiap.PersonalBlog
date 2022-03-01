define(['./template.js', '../lib/showdown/showdown.js'], function (template, showdown) {

    const blogPostsUrl = '/Home/LatestBlogPost/';
    const blogPostUrl = '/Home/Post/?link=';
    const loadMorePostsUrl = '/Home/MoreBlogPosts/?oldestBlogPostId=';

    var oldestBlogPostId = 0;

    function setOldestBlogPostId(data) {
        const ids = data.map(item => item.postId);
        console.log(data);
        console.log(Math.min(...ids));
        oldestBlogPostId = Math.min(...ids);
    }

    async function loadData(url) {
        try {
            const response = await fetch(url);
            const json = await response.json();
            template.appendBlogList(json);
            setOldestBlogPostId(json);
            console.log(oldestBlogPostId);
        } catch (e) {
            console.log('Error ao carregar data: ', e);
        }
    }

    async function loadLatestBlogPosts() {
        await loadData(blogPostsUrl);
    }

    function loadBlogPost(link) {
        fetch(blogPostUrl + link)
            .then(function (response) {
                return response.text();
            })
            .then(function (data) {
                const converter = new showdown.Converter();
                html = converter.makeHtml(data);
                template.showBlogItem(html, link);
                window.location = '#' + link;
            })
            .catch(function (error) {
                console.log('Erro ao carregar')
            });
    }

    async function loadMoreBlogPosts() {
        await loadData(loadMorePostsUrl + oldestBlogPostId);
    }

    return {
        loadLatestBlogPosts: loadLatestBlogPosts,
        loadBlogPost: loadBlogPost,
        loadMoreBlogPosts: loadMoreBlogPosts
    }
});