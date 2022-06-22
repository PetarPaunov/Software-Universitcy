import * as api from "./api.js";

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const endpoint = {
    all : '/data/cars?sortBy=_createdOn%20desc',
    byId : '/data/cars/',
    myItems: (userId) => `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    create: '/data/cars/',
    update: '/data/cars/',
    delete: '/data/cars/',
    getByQuery: (query) => `/data/cars?where=year%3D${query}`,
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

export function byQuery(query){
    return api.get(endpoint.getByQuery(query))
}



