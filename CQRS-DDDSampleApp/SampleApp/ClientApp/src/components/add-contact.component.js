import React, { Component } from "react";
import ContactService from "../services/contact.service";

export default class AddContact extends Component {
  constructor(props) {
    super(props);
    this.onChangeFullName = this.onChangeFullName.bind(this);
    this.onChangeEmail = this.onChangeEmail.bind(this);
    this.onChangePhoneNumber = this.onChangePhoneNumber.bind(this);
    this.onChangeAddress = this.onChangeAddress.bind(this);
    this.saveContact = this.saveContact.bind(this);
    this.newContact = this.newContact.bind(this);

    this.state = {
      id: null,
      fullName: "",
      email: "",
      phoneNumber: "",
      address: "",

      submitted: false
    };
  }

  onChangeFullName(e) {
    this.setState({
      fullName: e.target.value
    });
  }

  onChangeEmail(e) {
    this.setState({
      email: e.target.value
    });
  }

  onChangePhoneNumber(e) {
    this.setState({
      phoneNumber: e.target.value
    });
  }

  onChangeAddress(e) {
    this.setState({
      address: e.target.value
    });
  }

  saveContact() {
    var data = {
        fullName: this.state.fullName,
        email: this.state.email,
        phoneNumber: this.state.phoneNumber,
        address: this.state.address,
    };

    ContactService.create(data)
      .then(response => {
        this.setState({
          id: response.data.id,
          title: response.data.title,
          description: response.data.description,
          published: response.data.published,

          submitted: true
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
        alert(e.response.data.message);
      });
  }

  newContact() {
    this.setState({
      id: null,
      fullName: "",
      email: "",
      phoneNumber: "",
      address: "",

      submitted: false
    });
  }

  render() {
    return (
      <div className="submit-form">
        {this.state.submitted ? (
          <div>
            <h4>You submitted successfully!</h4>
            <button className="btn btn-success" onClick={this.newContact}>
              Add
            </button>
          </div>
        ) : (
          <div>
            <div className="form-group">
              <label htmlFor="fullName">Full Name</label>
              <input
                type="text"
                className="form-control"
                id="fullName"
                required
                value={this.state.fullName}
                onChange={this.onChangeFullName}
                name="fullName"
              />
            </div>

            <div className="form-group">
              <label htmlFor="email">Email</label>
              <input
                type="text"
                className="form-control"
                id="email"
                required
                value={this.state.email}
                onChange={this.onChangeEmail}
                name="email"
              />
            </div>

            <div className="form-group">
              <label htmlFor="phoneNumber">Phone Number</label>
              <input
                type="text"
                className="form-control"
                id="phoneNumber"
                required
                value={this.state.phoneNumber}
                onChange={this.onChangePhoneNumber}
                name="phoneNumber"
              />
            </div>

            <div className="form-group">
              <label htmlFor="address">Address</label>
              <input
                type="text"
                className="form-control"
                id="address"
                required
                value={this.state.address}
                onChange={this.onChangeAddress}
                name="address"
              />
            </div>

            <button onClick={this.saveContact} className="btn btn-success">
              Submit
            </button>
          </div>
        )}
      </div>
    );
  }
}