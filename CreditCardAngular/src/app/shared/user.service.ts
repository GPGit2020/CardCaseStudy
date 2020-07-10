import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:5000/api';

  /*****************user details*************************************/
  userModel = this.fb.group({
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    DOB: ['', Validators.required],
    AnnualSalary: ['', Validators.required],
  });

  userDetails() {
    var body = {
      FirstName: this.userModel.value.FirstName,
      LastName: this.userModel.value.LastName,
      DOB: this.userModel.value.DOB,
      AnnualSalary: this.userModel.value.AnnualSalary,
    };

    return this.http.post(this.BaseURI + '/UserDetail/UserProfile', body);
  }



  /***************************Card details ***********************************/
  cardModel = this.fb.group({
    UserCardStatus: [''],
    APROnCard: [0],
    UserPromotionalMsg: [''],
    UserId: [0]
  });

  cardDetails() {
    var body = {
      UserCardStatus: this.cardModel.value.UserCardStatus,
      APROnCard: this.cardModel.value.APROnCard,
      UserPromotionalMsg: this.cardModel.value.UserPromotionalMsg,
      UserId: this.cardModel.value.UserId
    };

    return this.http.post(this.BaseURI + '/UserDetail/ManageCard', body);
  }

}
