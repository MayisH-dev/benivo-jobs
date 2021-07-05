// import logo from './logo.svg'
import React, { useEffect, useState } from 'react'
import api from './Api'
import './App.css'
import JobCards from './JobCards'

import MultiSearch from './MultiSearch'

const App = () => {
  const [countByGroups, setCountByGroups] = useState({})
  const [jobs, setJobs] = useState({})

  const title = 'Benivo Jobs'

  const fetchCountsByGroups = async () => {
    const { data: countByGroupsResponse } = await api.get(
      '/jobs/count-by-groups'
    )
    setCountByGroups(countByGroupsResponse)
  }

  const fetchJobs = async () => {
    const {
      data: { jobs: jobsResponse },
    } = await api.get('/jobs/?Page.Number=1&Page.Size=20')
    setJobs(jobsResponse)
  }

  useEffect(() => {
    fetchCountsByGroups()
  }, [])

  useEffect(() => {
    fetchJobs()
  }, [])

  return (
    <div className='App'>
      <div className='content'>
        <h1>{title}</h1>
      </div>
      <div>
        <MultiSearch
          onChange={(locationIds) => {
            console.log(locationIds)
          }}
          placeholder='Locations'
          items={countByGroups.locations}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
        <MultiSearch
          onChange={(categoryId) => {
            console.log(categoryId)
          }}
          placeholder='Categories'
          items={countByGroups.categories}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
        <MultiSearch
          onChange={(employmentTypeId) => console.log(employmentTypeId)}
          placeholder='EmploymentTypes'
          items={countByGroups.employmentTypes}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
      </div>
      <div>
        <JobCards jobs={jobs} />
      </div>
    </div>
  )
}

export default App
