import React, { Component } from "react";
import ContactService from "../services/contact.service";
import { Link } from "react-router-dom";

export default class ContactsList extends Component {
  constructor(props) {
    super(props);
    this.retrieveContacts = this.retrieveContacts.bind(this);
    this.refreshList = this.refreshList.bind(this);
    this.setActiveContact = this.setActiveContact.bind(this);

    this.state = {
      contacts: [],
      currentContact: null,
      currentIndex: -1,
    };
  }

  componentDidMount() {
    this.retrieveContacts();
  }

  retrieveContacts() {
    ContactService.getAll()
      .then(response => {
        this.setState({
          contacts: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  refreshList() {
    this.retrieveContacts();
    this.setState({
      currentContact: null,
      currentIndex: -1
    });
  }

  setActiveContact(contact, index) {
    this.setState({
      currentContact: contact,
      currentIndex: index
    });
  }

  render() {
    const { contacts, currentContact, currentIndex } = this.state;

    return (
      <div className="list row">
        <div className="col-md-6">
          <h4>Contacts List</h4>

          <ul className="list-group">
            {contacts &&
              contacts.map((contact, index) => (
                <li
                  className={
                    "list-group-item " +
                    (index === currentIndex ? "active" : "")
                  }
                  onClick={() => this.setActiveContact(contact, index)}
                  key={index}
                >
                  {contact.fullName}
                </li>
              ))}
          </ul>

        </div>
        <div className="col-md-6">
          {currentContact ? (
            <div>
              <h4>Contact</h4>
              <div>
                <label>
                  <strong>Email:</strong>
                </label>{" "}
                {currentContact.email}
              </div>
              <div>
                <label>
                  <strong>Phone Number:</strong>
                </label>{" "}
                {currentContact.phoneNumber}
              </div>
              <div>
                <label>
                  <strong>Address:</strong>
                </label>{" "}
                {currentContact.address}
              </div>

              <Link
                to={"/contacts/" + currentContact.id}
                className="badge badge-warning"
              >
                Edit
              </Link>
            </div>
          ) : (
            <div>
              <br />
              <p>Please click on a Contact to see details.</p>
            </div>
          )}
        </div>
      </div>
    );
  }
}