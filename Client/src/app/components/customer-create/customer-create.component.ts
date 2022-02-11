import { CustomerService } from './../../services/customer.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.scss']
})
export class CustomerCreateComponent implements OnInit {

  customerForm: FormGroup;

  constructor(private fb: FormBuilder,
    private customerService: CustomerService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.createCustomerForm();
  }

  createCustomerForm() {
    this.customerForm = this.fb.group({
      surname: [null, [Validators.required]],
      name: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]
      ],
      mobile: [null, [Validators.required]],
      occupation: [null, [Validators.required]]
    });

  }

  onSubmit() {
    this.customerService.create(this.customerForm.value)
      .subscribe(() => {
        this.toastr.success('Customer successfully added!');
        this.router.navigateByUrl('/customers');
      }, error => {
        this.toastr.error("Problem on add new customer.");
        console.log(error);
      });
  }

}
