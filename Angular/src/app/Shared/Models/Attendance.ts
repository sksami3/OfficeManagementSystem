import { Base } from './Base';

export class Attendance extends Base {
    Start: Date;
    End: Date;
    ClientsDeviceInfo: string;
    WorkDetails: string;
    EmployeeId: number;
}