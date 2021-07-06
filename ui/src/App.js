// import logo from './logo.svg'
import React, { useEffect, useState } from 'react'
import api from './Api'
import './App.css'
import JobCards from './JobCards'
import MultiSearch from './MultiSearch'
import Search from 'antd/lib/input/Search'

const App = () => {
  const [filter, setFilter] = useState({
    categoryIds: [],
    employmentTypeIds: [],
    locationIds: [],
    title: '',
  })

  const [countByGroups, setCountByGroups] = useState({})
  const [jobs, setJobs] = useState({})

  const filterQuery = filter.categoryIds
    .map((c) => `CategoryIds=${c}`)
    .concat(filter.employmentTypeIds.map((e) => `EmploymentTypeIds=${e}`))
    .concat(filter.locationIds.map((j) => `LocationIds=${j}`))
    .join('&')
    .concat(filter.title === '' ? '' : `&Title=${filter.title}`)

  const fetchCountsByGroups = async () => {
    const { data: countByGroupsResponse } = await api.get(
      '/jobs/count-by-groups'.concat(
        filterQuery === '' ? '' : `?${filterQuery}`
      )
    )
    setCountByGroups(countByGroupsResponse)
  }

  const fetchJobs = async () => {
    const {
      data: { jobs: jobsResponse },
    } = await api.get(
      '/jobs/?Page.Number=1&Page.Size=20'.concat(
        filterQuery === '' ? '' : `&${filterQuery}`
      )
    )
    setJobs(jobsResponse)
  }

  useEffect(() => {
    fetchJobs()
    fetchCountsByGroups()
  }, [
    filter.locationIds,
    filter.employmentTypeIds,
    filter.categoryIds,
    filter.title,
  ])

  const title = 'Benivo Jobs'
  return (
    <div className='App'>
      <div className='content'>
        <h1>{title}</h1>
      </div>
      <div>
        <MultiSearch
          onChange={(locationIds) => {
            setFilter({ ...filter, locationIds })
          }}
          placeholder='Location'
          items={countByGroups.locations}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
        <MultiSearch
          onChange={(categoryIds) => {
            setFilter({ ...filter, categoryIds })
          }}
          placeholder='Category'
          items={countByGroups.categories}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
        <MultiSearch
          onChange={(employmentTypeIds) =>
            setFilter({ ...filter, employmentTypeIds })
          }
          placeholder='Employment Type'
          items={countByGroups.employmentTypes}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
        <Search
          placeholder='Job Title'
          onSearch={(title) => setFilter({ ...filter, title })}
          style={{ width: 320, paddingRight: 10, paddingLeft: 10 }}
        />
      </div>
      <br />
      <div>
        <JobCards jobs={jobs} />
      </div>
    </div>
  )
}

export default App
