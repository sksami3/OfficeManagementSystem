import { Employee } from '../Models/Employee';

export class helper {
    public CastToEmployee(post) {
        ////#region assigning values
        let e = new Employee();
        // this.employee = <Employee>post;
        e.Age = post.age;
        e.ContactNumber = post.contactnumber;
        e.DateOfBirth = new Date;//post.dob;
        e.DepartmentId = post.departmentList;
        e.Email = post.email;
        e.JoiningDate = new Date;//post.joiningdate;
        e.Name = post.name;
        e.Salary = post.salary;
        ////#endregion
    }
}