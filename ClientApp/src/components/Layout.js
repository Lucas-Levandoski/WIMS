import React, { Component } from 'react';
import { SchoolsList } from './SideList';
import { Map } from './Map';
import { FaLinkedin, FaGithub } from 'react-icons/fa';
import { IoIosSchool } from 'react-icons/io';
//import pin_school from '../assets/pin_school.png';
import pin_house from '../assets/pin_house.png';

import '../styles/layout.css';
import '../styles/pushPinPopUp.css';

 
export class Layout extends Component {
    static displayName = Layout.name;

    constructor(props) {
        super(props);
        this.aplicaDirection = this.aplicaDirection.bind(this);
        this.calcDistance = this.calcDistance.bind(this);
        this.setHouse = this.setHouse.bind(this);
        this.applyPushPins = this.applyPushPins.bind(this);
        this.state = {
            search: "",
            House: "",
            showSideList: true,
            loading: true,
            directions: {
                "requestOptions": { "routeMode": "driving", "maxRoutes": 1 },
                "wayPoints": [
                    {
                        location: []
                    },
                    {
                        location: []
                    }
                ]
            },
            schools: [],
            schoolsList: [],
            infoboxPushPins: [],
        }
    }

    componentDidMount() {
        this.populateSchoolData()
    }



    setHouse = (house) => {
        this.setState({ House: house });
        this.applyPushPins(house);
    }

    aplicaDirection = (location1, location2) => {
        location1 === "" ? alert("Tell me where is your house!"):
        this.setState({ directions: { wayPoints: [{ location: location1 }, { location: location2 }] } });
    }

    calcDistance = () => {
        if (this.state.House !== "") {
            this.setState({ loading: true });
            this.CalcDistance(this.state.House);
        }
        else {
            alert("Click or Touch on the map to show me where your house is");
        }
    }

    toggleSideList = () => {
        this.setState({ showSideList: this.state.showSideList ? false : true });
    }

    searchEngine = (searchString) => {
        this.setState({ search: searchString })
    }

    renderSideList() {
        return (
            <SchoolsList
                aplicaDirection={this.aplicaDirection}
                calcDistance={this.calcDistance}
                parentState={this.state}
                House={this.state.House}
                searchEngine={this.searchEngine}
                searchString={this.state.search}
            />
        )
    }

    render() {
        let contents = this.state.showSideList
            ? this.renderSideList()
            : <></>

        return (
            <div className="Layout">
                <div className="Header">
                    <h1 className="SiteName"><IoIosSchool/> Where Is My School ?! </h1>
                    <ul>
                        <li><a href="https://www.linkedin.com/in/lucas-levandoski-92201856?lipi=urn%3Ali%3Apage%3Ad_flagship3_profile_view_base_contact_details%3BqTHeZYk9RwuQQqn7JPp7zA%3D%3D">
                            <FaLinkedin />
                            LinkedIn lls 
                        </a></li>
                        <li><a href="https://github.com/Lucas-Levandoski" >
                            <FaGithub/>
                            GitHub lls
                        </a></li>
                    </ul>
                </div>
                <div className="Content">
                    {contents}
                    <Map
                        searchString={this.state.search}
                        setHouse={this.setHouse}
                        parentState={this.state}
                        showSideList={this.state.showSideList}
                        toggleSideList={this.toggleSideList}
                    />
                </div>
          </div>
        );
    }

    async populateSchoolData() {
        const response = await fetch('School/Index');
        const data = await response.json();
        //let a = this.state.infoboxPushPins.slice();
        let b = [];
        for (var i = 0; i < 30; i++) {
            //a.push({
            //    location: [data[i].latitude, data[i].longitude],
            //    addHandler: "mouseover",
            //    infoboxOption: {
            //        title: data[i].name,
            //        htmlContent:
            //            <div className="popup">
            //                <p className="nome"> {data[i].nome} </p>
            //                <p className="telefone"> (51) {data[i].telefone.substring(0, 4)}-{data[i].telefone.substring(4, 8)}</p>
            //                <p className="email"> {data[i].email} </p>
            //                <p className="site"><a href={data[i].url_website}> {data[i].url_website} </a></p>
            //                <p className="endereco"> {data[i].logradouro}, {data[i].bairro}, {data[i].numero} </p>
            //            </div>
            //    },
            //    pushPinOption: { title: data[i].abr_nome, color: 'blue' }
            //    //pushPinOption: { title: data[i].abr_nome, icon: pin_school, anchor: [10, 16] }
            //});
            b.push({ location: [data[i].latitude, data[i].longitude], name: data[i].nome, abr_nome: data[i].abr_nome, distance: "--", id : i});
        }
        this.setState({ schools: data, loading: false, schoolsList: b });
        this.applyPushPins();
    }

    async CalcDistance(house) {
        var response = await fetch(`Plot/calcDistance/${house[0]}/${house[1]}`)
        const b = await response.json();
        this.setState({ loading: false, schoolsList: b})
    }

    applyPushPins(house = 0) {
        var schools = this.state.schools;
        var a = [];
        for (var i = 0; i < 30; i++) {
            a.push({
                location: [schools[i].latitude, schools[i].longitude],
                addHandler: "mouseover",
                infoboxOption: {
                    title: schools[i].name,
                    htmlContent:
                        <div className="popup">
                            <p className="nome"> {schools[i].nome} </p>
                            <p className="telefone"> (51) {schools[i].telefone.substring(0, 4)}-{schools[i].telefone.substring(4, 8)}</p>
                            <p className="email"> {schools[i].email} </p>
                            <p className="site"><a href={schools[i].url_website}> {schools[i].url_website} </a></p>
                            <p className="endereco"> {schools[i].logradouro}, {schools[i].bairro}, {schools[i].numero} </p>
                        </div>
                },
                pushPinOption: { title: schools[i].abr_nome, color: 'blue' }
            });
        }
        if (house !== 0) {
            a.push({
                location: [house[0], house[1]],
                addHandler: "mouseover",
                infoboxOption: {
                    title: "you",
                    htmlContent:
                        <div className="popup">
                            <p className="nome"> You are here ! </p>
                        </div>
                },
                pushPinOption: { title: "You", "icon": pin_house, anchor: [1, 29] }
            })
        }

        this.setState({ infoboxPushPins: a });
    }

}

