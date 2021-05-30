
import { Col, Input, Row, Select, Form, Button, Collapse } from 'antd';
import { FormInstance } from 'antd/lib/form/Form';
import React from 'react';
import { User } from './reducer';
import { UserType, userTypes } from '../../helpers/types';
import { Room } from '../Rooms/reducer';

const FormItem = Form.Item;
const Option = Select.Option;
const { Panel } = Collapse;

interface PassedProps {
    userInfo?: User;
    mode?: 'add' | 'edit';
    handleSubmit: () => void;
    onChange: (fieldName: keyof User, fieldValue: any) => void;
    handleReset: () => void;
    isLoading: boolean;
    rooms?: Room[];
}

class UserForm extends React.Component<PassedProps>{

    formRef = React.createRef<FormInstance>();


    componentDidMount = () => {
        this.setInitialValues();
    }

    setInitialValues = () => {
        if (!this.formRef.current) return;

        const { mode, userInfo } = this.props;

        // update form fields
        switch (mode) {
            case 'edit':
                this.formRef.current.setFieldsValue({
                    "FirstName": userInfo?.FirstName,
                    "LastName": userInfo?.LastName,
                    "Email": userInfo?.Email,
                    "UserType": userInfo?.UserType
                });
                break;

            case 'add':
                this.formRef.current.setFieldsValue({
                    "UserType": "Guest"
                });
                break;

            default:
                break;
        }
    }



    onFinishFailed = (errorFields: any) => {
        if (this.formRef.current && errorFields[0]) {
            this.formRef.current.scrollToField(errorFields[0].name);
        }
    }

    handleUserTypeChange = (event: any, option: any) => {
        let value = (option && option.key ? Number(option.key) : null);
        this.props.onChange('UserTypeId', value);
        this.props.onChange('UserType', event);
    }

    handleRoomsChange = (rooms: string[]) => {
        if (!this.formRef.current) return;

        const names = rooms && rooms.length !== 0
            ? Array.from(new Set(rooms.map((i: string) => i.trim().replace(' ', '').toUpperCase())))
            : undefined;

        this.formRef.current.setFieldsValue({ "AvailableRooms": names });
        this.props.onChange('RoomNumbers', names);
    }

    render() {

        const { userInfo } = this.props;

        const userTypeOptions = userTypes.map((type: UserType) => {
            return <Option key={type.Id.toString()} value={type.Id.toString()}>{type.Name}</Option>;
        });

        const roomsOptions = this.props.rooms?.map((room: Room) => {
            return <Option key={room.Id.toString()} value={room.Id.toString()}>{room.Number}</Option>;
        });

        return <>

            <Form
                ref={this.formRef}
                onFinish={(e: any) => this.props.handleSubmit()}
                onFinishFailed={this.onFinishFailed}

            >

                <FormItem
                    name={"FirstName"}
                    label={`First name`}
                    rules={[{
                        required: true,
                        message: "First name is required"
                    }]}
                >

                    <Input
                        name="FirstName"
                        placeholder={"Please, input first name"}
                        onChange={(e: any) => {
                            this.props.onChange(e.target.name, e.target.value);
                        }} />

                </FormItem>


                <FormItem
                    name={"LastName"}
                    label={`Last name`}
                    rules={[{
                        required: true,
                        message: "Last name is required"
                    }]}
                >
                    <Input
                        name="LastName"
                        placeholder={"Please, input last name"}
                        onChange={(e: any) => {
                            this.props.onChange(e.target.name, e.target.value);
                        }} />

                </FormItem>

                <FormItem
                    name={"Email"}
                    label={`Email`}
                    rules={[{
                        required: true,
                        message: "Email is required"
                    }]}>

                    <Input
                        style={{ width: 384, marginLeft: 30 }}
                        name="Email"
                        placeholder={"Please, input email"}
                        onChange={(e: any) => {
                            this.props.onChange(e.target.name, e.target.value);
                        }} />

                </FormItem>

                <FormItem
                    label={"User type"}
                    name={"UserType"}
                    rules={[{
                        required: true,
                        message: "User type is required"
                    }]}>

                    <Select
                        style={{ width: 384, marginLeft: 5 }}
                        showSearch={true}
                        placeholder={"Please, select user type"}
                        optionFilterProp="children"
                        onChange={this.handleUserTypeChange}
                    >
                        {userTypeOptions}
                    </Select>
                </FormItem>

                <Collapse style={{ marginBottom: 20 }} >
                    <Panel header="Rooms access information" key="1">
                        <FormItem
                            name={"RFIDKey"}
                            label={`RFID Key`}
                        >
                            <Input
                                // style={{ width: 384, marginLeft: 20 }}
                                name="RFIDKey"
                                placeholder={"Please, input RFID key"}
                                onChange={(e: any) => {
                                    this.props.onChange(e.target.name, e.target.value);
                                }} />

                        </FormItem>
                        <FormItem
                            name={"AvailableRooms"}
                            label={`Available rooms`}
                        >
                            <Select
                                mode="multiple"
                                style={{ width: 384, marginLeft: 5 }}
                                showSearch={true}
                                placeholder={"Please, select available rooms"}
                                optionFilterProp="children"
                                onChange={(value: any, option: any) => this.handleRoomsChange(value)}
                            >
                                {roomsOptions}
                            </Select>

                        </FormItem>
                    </Panel>
                </Collapse>




                <FormItem>
                    <div>
                        <Button
                            htmlType="reset"
                            onClick={this.props.handleReset}
                        >
                            Cancel
                        </Button>
                        <Button
                            type="primary"
                            htmlType="submit"
                            loading={this.props.isLoading}
                        >
                            Save
                        </Button>
                    </div>
                </FormItem>


            </Form>
        </>
    }
}

export default UserForm;