import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-displaycard',
  templateUrl: './displaycard.component.html',
  styleUrls: ['./displaycard.component.css']
})
export class DisplaycardComponent implements OnInit {

  constructor() { }

  username: string = "";

  @Output() backHome = new EventEmitter<boolean>();

  @Input() fromResultMessage: string;
  @Input() alertClass: string;
  @Input() fromCurrentImage: string;

  ngOnInit() {
    this.username = sessionStorage.getItem("UserName");
  }

  backToHome() {
    this.backHome.emit(true);
  }
}
