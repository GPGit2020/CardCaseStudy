import { UserService } from './../../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})


export class RegistrationComponent implements OnInit {

  IsCardEligible: boolean = false;
  IsShowReg = true;
  IsSpinner = false;
  ResultMessage: string = "";
  PromotionalMessage: string = "";

  AlertClassParent: string = "";
  CurrentImage: string = "";

  arpCode: number = 0;

  cardType: string = "Check Your Credit Card!";


  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit() {

    this.service.userModel.reset();
    
  }

  backToHome(val) {
    this.IsCardEligible = false;
    this.IsShowReg = true;
    this.IsSpinner = false;
  }

  toggleText(val) {
    this.cardType ="Check Your "+ val +" Card!";

  }

  enableSpinner() {
    this.IsSpinner = true;
  }

  checkEligibility(userId) {

    let currentDate = new Date().getFullYear();
    let dob = this.service.userModel.get('DOB').value;
    let convertedDate = (new Date(dob)).getFullYear();
    let userAge = currentDate - convertedDate;
    let annualSal = this.service.userModel.get('AnnualSalary').value;
    
    if (userAge < 18) {
      this.arpCode = 0;
      this.ResultMessage = 'Sorry, You are not eligibile for any card.';
      this.AlertClassParent = "alert alert-danger";
      this.CurrentImage = "/../../assets/img/sad.png";
      
     
    }
    else if (userAge >= 18 && parseFloat(annualSal) >= 30000) {
      this.arpCode = 1;
      this.PromotionalMessage = "You will alos get the additional 2% cashback on your every purchase.";
      this.ResultMessage = 'Congratulations! You are eligibile for Barclay credit card on ' + this.arpCode + '% annual APR.' + this.PromotionalMessage;
      this.AlertClassParent = "alert alert-success";
      this.CurrentImage = "/../../assets/img/bar.png";
    }

    else {
      this.arpCode = 1.5;
      this.PromotionalMessage = "You will alos get the additional 1% cashback on your every purchase.";

      this.ResultMessage = 'Congratulations! You are eligibile for Vanquis credit card on ' + this.arpCode + ' % annual APR.' + this.PromotionalMessage;

      this.AlertClassParent = "alert alert-success";
      this.CurrentImage = "/../../assets/img/van.png";
    }


    this.service.cardModel.setValue({
      UserCardStatus: this.ResultMessage,
      APROnCard: this.arpCode,
      UserPromotionalMsg: this.PromotionalMessage,
      UserId: userId
    });

    this.saveCardDetails();
    this.service.userModel.reset();
  }

  saveCardDetails() {
    this.service.cardDetails().subscribe(
      (res: any) => {
        if (res.id) {
         
        } else {
          res.errors.forEach(element => {
            this.toastr.error('There are something wrong, please try again.');

          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }


  onSubmit() {
    this.service.userDetails().subscribe(
      (res: any) => {
        if (res.id) {
          this.IsCardEligible = true;
          this.IsShowReg = false;
          
          sessionStorage.setItem("UserName", res.firstName + " " + res.lastName);
          this.checkEligibility(res.id);
        } else {
          this.toastr.error('Something went wrong, please check.');

        }
      },
      err => {
        console.log(err);
      }
    );
  }

}
