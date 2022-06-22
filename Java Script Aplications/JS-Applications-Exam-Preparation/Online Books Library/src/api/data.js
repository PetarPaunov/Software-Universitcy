import * as api from "./api.js";

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const endpoint = {
    all : '/data/books?sortBy=_createdOn%20desc',
    byId : '/data/books/',
    myItems: (userId) => `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    create: '/data/books',
    update: '/data/books/',
    delete: '/data/books/',
    likeBook: `/data/likes`,
    likesCount: (bookId) => `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    myLikes: (bookId, userId) => `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count` 
}

export async function getAll(){
    return api.get(endpoint.all);
}

export async function getById(id){
    return api.get(endpoint.byId + id);
}

export async function getMyItems(userId){
    return api.get(endpoint.myItems(userId));
}

export async function createItem(data){
    return api.post(endpoint.create, data);
}

export async function updateItem(id, data){
    return api.put(endpoint.update + id, data);
}

export async function deleteItem(id){
    return api.del(endpoint.delete + id);
}

export async function like(data){
    return api.post(endpoint.likeBook, data)
}

export async function getLikes(bookId){
    return api.get(endpoint.likesCount(bookId))
}

export async function myLikes(bookId, userId){
    return api.get(endpoint.myLikes(bookId, userId));
}




