import * as api from "./api.js";

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const endpoint = {
    all : '/data/theaters?sortBy=_createdOn%20desc&distinct=title',
    byId : '/data/theaters/',
    myItems: (userId) => `/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    create: '/data/theaters',
    update: '/data/theaters/',
    delete: '/data/theaters/',
    like: `/data/likes`,
    hasLike: (theaterId, userId) => `/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
    getLikesCount: (theaterId) => `/data/likes?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`
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

export async function postLike(data){
    return api.post(endpoint.like, data)
}

export async function getHasLike(theaterId, userId){
    return api.get(endpoint.hasLike(theaterId, userId));
}

export async function getCountLikes(theaterId){
    return api.get(endpoint.getLikesCount(theaterId));
}





