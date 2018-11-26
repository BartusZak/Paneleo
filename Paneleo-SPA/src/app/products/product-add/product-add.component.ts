import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import { TitleService } from 'src/app/_services/title.service';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  addProductForm: FormGroup;
  constructor(private titleService: TitleService, private fb: FormBuilder) {}

  ngOnInit() {
    this.titleService.setTitle('Dodawanie produktu');
    this.createAddProductForm();
  }

  createAddProductForm() {
    this.addProductForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(40)]],
      quantity: [0, Validators.min(0)]
    });
  }

  addProduct() {
    console.log(this.addProductForm);
  }
}
