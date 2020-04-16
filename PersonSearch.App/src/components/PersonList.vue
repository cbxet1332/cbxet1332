<template>
    <div id="person-list-content">
        <p>Showing {{ PersonCount }} {{ PersonCountSuffix }}</p>
        <table align="left">
            <thead>
                <tr>
                    <th align="right">Id</th>
                    <th align="left">Person</th>
                    <th align="left">Group</th>
                    <th align="left"><em>Date Added</em></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td align="center" valign="middle">*</td>
                    <td align="left">
                        <input type="text"
                               class="form-control"
                               v-model.lazy="AddPersonText"
                               placeholder="Enter Person Name" />
                    </td>
                    <td align="left">
                        <select class="form-control" v-model="AddGroupId">
                            <option class="option-placeholder" value="0" disabled>Choose Group...</option>
                            <option v-for="group in GroupData"
                                    :key="group.Id"
                                    :value="group.Id">
                                {{ group.Name }}
                            </option>
                        </select>
                    </td>
                    <td align="left">
                        <button class="btn btn-secondary" type="button" @click="onButtonClick">Add</button>
                    </td>
                </tr>
                <tr v-for="person in PersonData" :key="person.Id">
                    <td align="right"><router-link :to="'/person/' + person.Id">{{ person.Id }}</router-link></td>
                    <td align="left">{{ person.Name }}</td>
                    <td align="left">{{ person.Group.Name }}</td>
                    <td align="left" class="read-only"><em>{{ person.CreatedLocal | formatDate }}</em></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        name: "person-list",
        inject: ['connect'],
        created: function () {
            this.vm = this.connect("PersonList", this, {
                watch: [
                    'AddPersonText',
                    'AddGroupId']
            });
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        data() {
            return {
                PersonData: [],
                PersonCount: 0,
                PersonCountSuffix: 'people',
                AddPersonText: '',
                AddGroupId: 0,
                GroupData: [],
                FilterText: ''
            }
        },
        props: {},
        methods: {
            onButtonClick: function () {
                this.vm.$dispatch({ 
                    AddPerson: { 
                        PersonName: this.AddPersonText, 
                        GroupId: this.AddGroupId 
                    } 
                });
            }
        }
    };
</script>

<style type="text/css">
    #person-list-content {
        margin-top: 20px;
    }
    .bold {
        font-weight: bold;
    }
    table {
        border-collapse: collapse;
    }
    table td, table th {
        border: 1px solid #888;
        padding: 8px;
    }
    table th {
        background-color: burlywood
    }
    table .read-only {
        color: darkgrey;
    }
    option .option-placeholder {
        color: darkgrey;
        font-style: italic;
    }
</style>

