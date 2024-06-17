import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
interface Property {
  id: number
  propertyType: string;
  location: string;
  price: number;
  numberOfRooms: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  public properties: Property[] = [];
  public apiUrl: string = 'http://localhost:5182/api/Property';
  isShowSaveBtn = false;
  isShowUpdateBtn = false;


  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getProperties();
  }
  displayStyle = "none";

  openPopup() {
    this.displayStyle = "block";
    this.isShowSaveBtn = true;
    this.isShowUpdateBtn = false;
    (document.getElementById("propertyModalLabel") as HTMLInputElement).innerHTML = "Save Property";
  }
  openPopupUpdate() {
    this.displayStyle = "block";
    this.isShowSaveBtn = false;
    this.isShowUpdateBtn = true;
    (document.getElementById("propertyModalLabel") as HTMLInputElement).innerHTML = "Update Property";
  }
  closePopup() {
    this.displayStyle = "none";
  }
  getProperties() {
    this.http.get<Property[]>(this.apiUrl).subscribe(
      (result) => {
        this.properties = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getProperty(val: any) {
    this.isShowSaveBtn = false;
    this.isShowUpdateBtn = true;
    this.http.get<Property>(this.apiUrl + '/' + val).subscribe(
      (result) => {
        (document.getElementById("propertyid") as HTMLInputElement).value = result.id.toString();
        (document.getElementById("propertytype") as HTMLInputElement).value = result.propertyType;
        (document.getElementById("location") as HTMLInputElement).value = result.location;
        (document.getElementById("price") as HTMLInputElement).value = result.price.toString();
        (document.getElementById("numberofrooms") as HTMLInputElement).value = result.numberOfRooms.toString();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  updateProperty() {
    let property = {
      id: (document.getElementById("propertyid") as HTMLInputElement).value,
      propertyType: (document.getElementById("propertytype") as HTMLInputElement).value,
      location: (document.getElementById("location") as HTMLInputElement).value,
      price: (document.getElementById("price") as HTMLInputElement).value,
      numberOfRooms: (document.getElementById("numberofrooms") as HTMLInputElement).value
    }
    return this.http.put(this.apiUrl, property).subscribe(response => {
      if (response) {
        alert("Property is Updated");
      }
      else {
        alert("Property is not updated");
      }
    });
  }

  deleteProperty(val: any) {

    return this.http.delete(this.apiUrl + '/' + val).subscribe(response => {
      if (response) {
        alert("Property is deleted");

      }
      else {

        alert("Property is not deleted");
      }
    });
  }

  createProperty() {

    let property = {
      propertyType: (document.getElementById("propertytype") as HTMLInputElement).value,
      location: (document.getElementById("location") as HTMLInputElement).value,
      price: (document.getElementById("price") as HTMLInputElement).value,
      numberOfRooms: (document.getElementById("numberofrooms") as HTMLInputElement).value
    }

    this.http.post(this.apiUrl, property)
      .subscribe(response => {
        if (response) {
          alert("Property is Saved");
        }
        else {
          alert("Property is not saved");
        }
      });
  }

  title = 'realestatepropertysearch.client';
}
