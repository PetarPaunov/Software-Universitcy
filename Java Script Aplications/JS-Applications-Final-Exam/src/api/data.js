import * as api from "./api.js";

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const endpoint = {
    all : '/data/pets?sortBy=_createdOn%20desc&distinct=name',
    byId : '/data/pets/',
    myItems: (userId) => `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    create: '/data/pets',
    update: '/data/pets/',
    delete: '/data/pets/',
    postDonations: `/data/donation`,
    getDonationsCout: (petId) => `/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`,
    isDonated: (petId, userId) => `/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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

export async function donate(data){
    return api.post(endpoint.postDonations, data);
}

export async function donationCout(petId){
    return api.get(endpoint.getDonationsCout(petId));
}

export async function isDonator(petId, userId){
    return api.get(endpoint.isDonated(petId, userId));
}



