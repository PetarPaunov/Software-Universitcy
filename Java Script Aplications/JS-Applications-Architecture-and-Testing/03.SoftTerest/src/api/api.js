const host = 'http://localhost:3030';

async function requests(method, url, data){
    let options = {
        method,
        headers: {}
    };

    if(data != undefined){
        options.headers['Content-Type'] = 'aplication/json';
        options.body = JSON.stringify(data);
    }

    let user = JSON.parse(localStorage.getItem('user'));
    if(user){
        let token = user.accessToken;
        options.headers['X-Authorization'] = token;
    }

    try {
        let response = await fetch(host + url, options);

        if(response.ok != true){
            if(response.status == 403){
                localStorage.removeItem('user');
            }
            let error = await response.json();
            throw new Error(error.message);
        }
        if(response.status == 204){
            return response;
        }else{
            return response.json();
        }
    } catch (error) {
        alert(error.message);
        throw error;
    }
}


const get = requests.bind(null, 'GET');
const post = requests.bind(null, 'POST');
const put = requests.bind(null, 'PUT');
const del = requests.bind(null, 'DELETE');

export{
    get,
    post,
    put,
    del 
}