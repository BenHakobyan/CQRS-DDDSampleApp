import React, { Component } from "react";
import ContactService from "../services/contact.service";

export default class Contact extends Component {
  constructor(props) {
    super(props);
    this.onChangeFullName = this.onChangeFullName.bind(this);
    this.onChangeEmail = this.onChangeEmail.bind(this);
    this.onChangePhoneNumber = this.onChangePhoneNumber.bind(this);
    this.onChangeAddress = this.onChangeAddress.bind(this);
    this.getContact = this.getContact.bind(this);
    this.updateContact = this.updateContact.bind(this);
    this.deleteContact = this.deleteContact.bind(this);

    this.state = {
      currentContact: {
        id: null,
        fullName: "",
        email: "",
        phoneNumber: "",
        address: ""
      },
      message: ""
    };
  }

  componentDidMount() {
    this.getContact(this.props.match.params.id);
  }

  onChangeFullName(e) {
    const fullName = e.target.value;

    this.setState(function(prevState) {
      return {
        currentContact: {
          ...prevState.currentContact,
          fullName: fullName
        }
      };
    });
  }

  onChangeEmail(e) {
    const email = e.target.value;
    
    this.setState(prevState => ({
      currentContact: {
        ...prevState.currentContact,
        email: email
      }
    }));
  }

  onChangePhoneNumber(e) {
    const phoneNumber = e.target.value;
    
    this.setState(prevState => ({
      currentContact: {
        ...prevState.currentContact,
        phoneNumber: phoneNumber
      }
    }));
  }

  onChangeAddress(e) {
    const address = e.target.value;
    
    this.setState(prevState => ({
      currentContact: {
        ...prevState.currentContact,
        address: address
      }
    }));
  }

  getContact(id) {
    ContactService.get(id)
      .then(response => {
        this.setState({
          currentContact: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  updateContact() {
    ContactService.update(
      this.state.currentContact.id,
      this.state.currentContact
    )
      .then(response => {
        console.log(response.data);
        this.setState({
          message: "The Contact was updated successfully!"
        });
      })
      .catch(e => {
        console.log(e);
        alert(e.response.data.message);
      });
  }

  deleteContact() {    
    ContactService.delete(this.state.currentContact.id)
      .then(response => {
        console.log(response.data);
        this.props.history.push('/contacts')
      })
      .catch(e => {
        console.log(e);
        alert(e.response.data.message);
      });
  }

  render() {
    const { currentContact } = this.state;

    return (
      <div>
        {currentContact ? (
          <div className="edit-form">
            <h4>Contact</h4>
            <form>
              <div className="form-group">
                <label htmlFor="fullName">FullName</label>
                <input
                  type="text"
                  className="form-control"
                  id="fullName"
                  value={currentContact.fullName}
                  onChange={this.onChangeFullName}
                />
              </div>
              <div className="form-group">
                <label htmlFor="email">Email</label>
                <input
                  type="text"
                  className="form-control"
                  id="email"
                  value={currentContact.email}
                  onChange={this.onChangeEmail}
                />
              </div>
              <div className="form-group">
                <label htmlFor="phoneNumber">Phone Number</label>
                <input
                  type="text"
                  className="form-control"
                  id="phoneNumber"
                  value={currentContact.phoneNumber}
                  onChange={this.onChangePhoneNumber}
                />
              </div>
              <div className="form-group">
                <label htmlFor="address">Address</label>
                <input
                  type="text"
                  className="form-control"
                  id="address"
                  value={currentContact.address}
                  onChange={this.onChangeAddress}
                />
              </div>

            </form>

            <button
              className="badge badge-danger mr-2"
              onClick={this.deleteContact}
            >
              Delete
            </button>

            <button
              type="submit"
              className="badge badge-success"
              onClick={this.updateContact}
            >
              Update
            </button>
            <p>{this.state.message}</p>
          </div>
        ) : (
          <div>
            <br />
            <p>Please click on a Contact...</p>
          </div>
        )}
      </div>
    );
  }
}