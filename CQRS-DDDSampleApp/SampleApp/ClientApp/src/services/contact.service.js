import http from "../http-common";

class ContactService {
  getAll() {
    return http.get("/contacts");
  }

  get(id) {
    return http.get(`/contacts/${id}`);
  }

  create(data) {
    return http.post("/contacts", data);
  }

  update(id, data) {
    return http.put(`/contacts/${id}`, data);
  }

  delete(id) {
    return http.delete(`/contacts/${id}`);
  }
}

export default new ContactService();