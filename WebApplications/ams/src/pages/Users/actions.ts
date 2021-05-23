import axios from '../../api/axiosInstance';
import { User } from './reducer';

// get users
export enum GET_USERS {
    REQUEST = 'GET_USERS_REQUEST',
    SUCCESS = 'GET_USERS_SUCCESS',
}
export const getUsersRequest = () => {
    return {
        type: GET_USERS.REQUEST
    };
};

export const getUsersSuccess = (users: User[]) => {
    return {
        type: GET_USERS.SUCCESS,
        users: users
    };
};

export const getUsers = () => {
    return (dispatch: any) => {
        dispatch(getUsersRequest());
        axios.get(`users`)
            .then(response => {
                dispatch(getUsersSuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ', error.response);  //will be antd alert with good design
            });
    };
};

// add user
export enum ADD_USER {
    REQUEST = 'ADD_USER_REQUEST',
    SUCCESS = 'ADD_USER_SUCCESS',
}
export const addUserRequest = () => {
    return {
        type: ADD_USER.REQUEST
    };
};

export const addUserSuccess = (user: User) => {
    return {
        type: ADD_USER.SUCCESS,
        user: user
    };
};

export const addUser = (user : User) => {

    //TODO: Refactor request params

    // public int Id { get; set; }
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public string Email { get; set; }
    //     public int UserTypeId { get; set; }
    //     public string IdentityLockUserId { get; set; }
    //     public List<int> PrinterIds { get; set; }
    //     public int ComputerId { get; set; }
    //     public List<string> AllowedPlasticTypes { get; set; }
    //     public int AllowedPlasticQuantity { get; set; }
    //     public int UserId { get; set; }
    //     public DateTime? ValidFrom { get; set; }
    //     public DateTime? ValidTo { get; set; }


        const data = {
            Id: 0,
            FirstName : user.FirstName,
            LastName : user.LastName,
            Email : user.Email,
            UserTypeId : user.UserTypeId,
            IdentityLockUserId : 0,
            PrinterIds: [0],
            ComputerId: 0,
            AllowedPlasticTypes: ["ABS"],
            AllowedPlasticQuantity: 10,
            UserId: 0
        }


    return (dispatch: any) => {
        dispatch(addUserRequest());
        axios.post(`users`, data)
            .then(response => {
                dispatch(addUserSuccess(response.data));
            })
            .catch((error: any) => {
                console.log('ERROR: ', error.response);  //will be antd alert with good design
            });
    };
};
