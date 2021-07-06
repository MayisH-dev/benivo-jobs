// import logo from './logo.svg'
import React, { useEffect, useState } from 'react'
import api from './Api'
import './App.css'
import JobCards from './JobCards'
import MultiSearch from './MultiSearch'
import Search from 'antd/lib/input/Search'
import Pager from './Pager'

const App = () => {
  const [filter, setFilter] = useState({
    categoryIds: [],
    employmentTypeIds: [],
    locationIds: [],
    title: '',
    pageSize: 20,
    pageNumber: 1
  })

  const [countByGroups, setCountByGroups] = useState({})
  const [jobs, setJobs] = useState([])


  // const buildQuery = () => {
  //   const urlSearchParams = new URLSearchParams
  // }

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

  const addBookmark = async (id) => {
    const { status } = await api.patch(`/jobs/${id}/add-bookmark`)
    if (status === 200)
      setJobs(
        jobs.map((job) =>
          job.id === id ? { ...job, isBookmarked: true } : job
        )
      )
  }

  const removeBookmark = async (id) => {
    const { status } = await api.patch(`/jobs/${id}/remove-bookmark`)
    if (status === 200)
      setJobs(
        jobs.map((job) =>
          job.id === id ? { ...job, isBookmarked: false } : job
        )
      )
  }

  const fetchJobs = async () => {
    const {
      data: { jobs: jobsResponse },
    } = await api.get(
      `/jobs/?Page.Number=${filter.pageNumber}&Page.Size=${filter.pageSize}`.concat(
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
          change={(locationIds) => {
            setFilter({ ...filter, locationIds })
          }}
          placeholder='Location'
          items={countByGroups.locations}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
        <MultiSearch
          change={(categoryIds) => {
            setFilter({ ...filter, categoryIds })
          }}
          placeholder='Category'
          items={countByGroups.categories}
          style={{ paddingRight: 10, paddingLeft: 10, width: 320 }}
        />
        <MultiSearch
          change={(employmentTypeIds) =>
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
      <Pager
        total = {6000}
        // total={countByGroups.categoryIds.reduce((acc, cat) => acc + item, 0)}
      />
      <br />

      <div>
        <JobCards
          onRemoveBookmark={removeBookmark}
          onAddBookmark={addBookmark}
          jobs={jobs}
          size={filter.pageSize}
          current={filter.pageNumber}
          onChange={(pageNumber,pageSize) => {
            console.log("setting filter", pageSize, pageNumber)
            setFilter({...filter, pageSize, pageNumber})}}
        />
      </div>
    </div>
  )
}

export default App
