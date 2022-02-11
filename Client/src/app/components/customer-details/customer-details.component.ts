import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ICustomer } from './../../models/customer';
import { CustomerService } from './../../services/customer.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.scss']
})
export class CustomerDetailsComponent implements OnInit {

  customer: ICustomer;
  customerUpdateForm: FormGroup;

  constructor(private activatedRoute: ActivatedRoute,
    private customerService: CustomerService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.createCustomerUpdateForm();
    this.customerService.getCustomer(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe((customer: ICustomer) => {
        this.customerUpdateForm.patchValue(customer);
      }, error => {
        console.log(error);
      });
  }

  createCustomerUpdateForm() {
    this.customerUpdateForm = this.fb.group({
      surname: [null, [Validators.required]],
      name: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]
      ],
      mobile: [null, [Validators.required]],
      occupation: [null, [Validators.required]]
    });
  }

  onSubmit() {
    this.customerService.update(
      {
        id: +this.activatedRoute.snapshot.paramMap.get('id'),
        ...this.customerUpdateForm.value
      })
      .subscribe(() => {
        this.toastr.success("Update Successfully")
        this.router.navigateByUrl('/customers');


      }, error => {
        this.toastr.error("Problem on update customer.");
        console.log(error);
      });
  }

  onDelete() {
    this.customerService.delete(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(() => {
        this.toastr.success("Delete Successfully")
        this.router.navigateByUrl('/customers');
      }, error => {
        this.toastr.error("Problem on delete customer.");
        console.log(error);
      });
  }
}
